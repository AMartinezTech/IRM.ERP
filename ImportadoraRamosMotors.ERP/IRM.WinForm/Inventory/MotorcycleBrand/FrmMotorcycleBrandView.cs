using IRM.Application.Inventory.Items.MotorcycleBrand;
using IRM.WinForm.Inventory.MotorcycleModel;
using IRM.WinForm.Utils;
using IRM.WinForm.Utils.DataGrid;
using IRM.WinForm.Utils.Factories;
using IRM.WinForm.Utils.Messages;
using System.ComponentModel;

namespace IRM.WinForm.Inventory.MotorcycleBrand;

public partial class FrmMotorcycleBrandView : Form
{
    private readonly IFormFactory _formFactory;
    private CancellationTokenSource? _cts;
    private Guid BrandId { get; set; }
    private BindingList<MotorcycleBrandDto> _brandsList;
    private readonly MotorcycleBrandServices _brandServices;
    public FrmMotorcycleBrandView(MotorcycleBrandServices brandServices, IFormFactory formFactory)
    {
        InitializeComponent();
        _brandServices = brandServices;
        _brandsList = [];
        _formFactory = formFactory;

        SetColorUI();
    }

    private void FrmMotorcycleBrandView_Load(object sender, EventArgs e)
    {
        SetMessage("Alertas!.", MessageType.Information);
        InvokeDataViewSetting();
        InvokeFilterAsync();

    }
    #region "Methods"
    private async void InvokeGetByIdAsync(Guid id)
    {
        try
        {
            _cts = new CancellationTokenSource();
            var data = await _brandServices.GetByIdAsync(id);
            TxtName.Text = data.Name;
            CBIsActive.Checked = data.IsActive;
            BtnModel.Visible = true;
        }
        catch (Exception ex)
        {
            var message = DomainMessageSplit.SplitMessage(ex.Message);
            ValidationFields(message.FieldName);

            SetMessage("Cerrar - " + message.Message, MessageType.Warning);

            // Set to 3 secons for alert
            await SetInitialMessage(4, LabelAlertMessage);
        }
        finally
        {
            if (_cts != null)
            {
                _cts.Dispose();
                _cts = null;
            }
        }
    }
    private void ClearFields()
    {
        ClearMessageErr();
        BrandId = Guid.Empty;
        TxtName.Text = string.Empty;
        BtnModel.Visible = false;
        BtnPersistence.Enabled = true;
        DataGridView.Refresh();
    }
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelTopLine.BackColor = AppColors.Primary;
        PanelBottomLine.BackColor = AppColors.Outline;
        PanelBottomTitle.BackColor = AppColors.Primary;

        //Buttons icon color
        BtnClear.IconColor = AppColors.Secondary;
        BtnPersistence.IconColor = AppColors.Secondary;

        //Buttons text color 
        BtnClear.ForeColor = AppColors.OnSurface;
        BtnPersistence.ForeColor = AppColors.OnSurface;

        //Label
        LabelTitle.ForeColor = AppColors.OnPrimary;

    }
    private void ClearMessageErr()
    {
        errorProvider1.Clear();

        if (LabelAlertMessage.Text.Contains("Alertas!."))
        {
            return;
        }

        SetMessage("Alertas!.", MessageType.Information);
    }
    private async Task SetInitialMessage(int seconds, Label messageLabel)
    {
        messageLabel.Click += (sender, e) =>
        {
            _cts?.Cancel();

        };
        try
        {
            // Cambiar a mensaje inicial
            var countdown = new CountdownTimer(seconds,
                onCountdownFinished: () => SetMessage("Alertas!.", MessageType.Information));

            // Inicia la cuenta establecida en CountdownTimer y espera
            await countdown.StartAsync(_cts!.Token);
        }
        catch (OperationCanceledException)
        {
            // Captura la cancelación del temporizador
            SetMessage("Alertas!.", MessageType.Information);

        }
        finally
        {
            if (_cts != null)
            {
                _cts.Dispose();
                _cts = null;
            }
        }
    }
    private void SetMessage(string message, MessageType type)
    {

        var msg = new HandlerMessages(message, type);
        LabelAlertMessage.Text = $"{msg.Icon} {msg.Message}";
        LabelAlertMessage.ForeColor = msg.MessageColor;
    }
    private void InvokeDataViewSetting()
    {
        try
        {
            DataGridView.SetCustomDesign(new CustomDataGridViewParams
            {
                EditColumnView = true,
                EditColumnName = "EDITAR",
                DeleteColumnView = true,
                DeleteColumnName = "BORRAR",
            });
            // Set custom columns
            MotorcycleBrandFormatingDGColumns.Apply(DataGridView);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private async void InvokeFilterAsync()
    {

        var result = await _brandServices.FilterAsync();
        _brandsList = new BindingList<MotorcycleBrandDto>(result);

        if (_brandsList.Count > 0)
        {
            DataGridView.DataSource = _brandsList;
        }
        LblLoadingData.Visible = false;
        DataGridView.Visible = true;
    }
    private void ValidationFields(string fieldName)
    {

        if (fieldName.Contains("Name"))
        {
            TxtName.Focus();
            errorProvider1.SetError(TxtName, "Aquí!");
        }
    }
    #endregion

    private void TxtName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void BtnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }

    private async void BtnPersistence_Click(object sender, EventArgs e)
    {
        ClearMessageErr();
        _cts = new CancellationTokenSource();
        try
        {

            BtnPersistence.Enabled = false;
            var newDto = new MotorcycleBrandDto
            {
                Id = BrandId,
                Name = TxtName.Text.Trim(),
                IsActive = CBIsActive.Checked,
            };
            BrandId = await _brandServices.PersistenceAsync(newDto);
            newDto.Id = BrandId;

            MotorcycleBrandUpdatingMemoryData.Excecute(newDto, _brandsList);
            DataGridView.DataSource = _brandsList;
            ClearFields();
        }
        catch (OperationCanceledException ex)
        {
            SetMessage(ex.Message, MessageType.Warning);
            // Set to 2 secons for alert
            await SetInitialMessage(2, LabelAlertMessage);
            BtnPersistence.Enabled = true;
        }
        catch (Exception ex)
        {
            var message = DomainMessageSplit.SplitMessage(ex.Message);
            ValidationFields(message.FieldName);

            SetMessage("Cerrar - " + message.Message, MessageType.Warning);

            // Set to 3 secons for alert
            await SetInitialMessage(4, LabelAlertMessage);
            BtnPersistence.Enabled = true;
        }
        finally
        {
            if (_cts != null)
            {
                _cts.Dispose();
                _cts = null;
            }
        }
    }

    private async void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column
        BrandId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            InvokeGetByIdAsync(BrandId);
        }
        else if (DataGridView.Columns[e.ColumnIndex].Name == "deleteCol")
        {
            if (MessageBox.Show("¿Seguro que desea borrar el registro?... No se recueperará!", "Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _cts = new CancellationTokenSource();
                    await _brandServices.DeleteAsync(BrandId);

                    // Remove from datagrid
                    DataGridView.Rows.RemoveAt(e.RowIndex);

                    // Success Alert
                    SetMessage("Cerrar - El registro se borró correctamente.", MessageType.Success);

                    // Await 2 seconds
                    await SetInitialMessage(2, LabelAlertMessage);
                }
                catch (Exception ex)
                {
                    var message = DomainMessageSplit.SplitMessage(ex.Message);
                    ValidationFields(message.FieldName);

                    SetMessage("Cerrar - " + message.Message, MessageType.Warning);

                    // Set to 3 secons for alert
                    await SetInitialMessage(4, LabelAlertMessage);
                }
                finally
                {

                    if (_cts != null)
                    {
                        _cts.Dispose();
                        _cts = null;
                    }
                }
            }
        }
    }

    private void BtnModel_Click(object sender, EventArgs e)
    {
        var frmMotorcycleModel = _formFactory.CreateFormFactory<FrmMotorcycleModelView>();
        frmMotorcycleModel.BrandId = BrandId;
        frmMotorcycleModel.LblBrandName.Text = $"Marca: {TxtName.Text}";
        frmMotorcycleModel.ShowDialog();
    }
}
