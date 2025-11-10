using IRM.WinForm.Utils;
using IRM.Core.Exceptions;
using System.ComponentModel;
using IRM.WinForm.Utils.DataGrid;
using IRM.WinForm.Utils.Messages; 
using IRM.WinForm.Inventory.MotorcycleBrand;
using IRM.Application.Inventory.Items.MotorcycleModel;

namespace IRM.WinForm.Inventory.MotorcycleModel;

public partial class FrmMotorcycleModelView : Form
{
    private CancellationTokenSource? _cts;
    private Guid ModelId { get; set; }
    public required Guid BrandId;
    private BindingList<MotorcycleModelDto> _modelsList;
    private readonly MotorcycleModelServices _modelServices;
    public FrmMotorcycleModelView(MotorcycleModelServices modelServices)
    {
        InitializeComponent();
        _modelServices = modelServices;
        _modelsList = [];
        SetColorUI();
    }

    private void FrmMotorcycleModelView_Load(object sender, EventArgs e)
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
            var data = await _modelServices.GetByIdAsync(id);
            TxtName.Text = data.Name;
            CBIsActive.Checked = data.IsActive;
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
        ModelId = Guid.Empty;
        TxtName.Text = string.Empty;

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
        try
        {
            var filters = new Dictionary<string, object?>
            {
                ["brand_id"] = BrandId.ToString(),
            };
             
            var result = await _modelServices.FilterAsync(filters: filters);
            _modelsList = new BindingList<MotorcycleModelDto>(result);

            if (_modelsList.Count > 0)
            {
                DataGridView.DataSource = _modelsList;
            }
            LblLoadingData.Visible = false;
            DataGridView.Visible = true;
        }
        catch (BusinessRuleException brex)
        {
            MessageBox.Show(brex.Message);
        }
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
            var newDto = new MotorcycleModelDto
            {
                Id = ModelId,
                Name = TxtName.Text.Trim(),
                IsActive = CBIsActive.Checked,
                BrandId = BrandId,
            };
            ModelId = await _modelServices.PersistenceAsync(newDto);
            newDto.Id = ModelId;

            MotorcycleModelUpdatingMemoryData.Excecute(newDto, _modelsList);
            DataGridView.DataSource = _modelsList;
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
        ModelId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            InvokeGetByIdAsync(ModelId);
        }
        else if (DataGridView.Columns[e.ColumnIndex].Name == "deleteCol")
        {
            if (MessageBox.Show("¿Seguro que desea borrar el registro?... No se recueperará!", "Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _cts = new CancellationTokenSource();
                    await _modelServices.DeleteAsync(ModelId);

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
}
