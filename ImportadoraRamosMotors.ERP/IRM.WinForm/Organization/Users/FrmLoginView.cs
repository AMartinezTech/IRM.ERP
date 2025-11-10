using IRM.WinForm.Utils;
using IRM.WinForm.Utils.Messages; 

namespace IRM.WinForm.Organization.Users;

public partial class FrmLoginView : Form
{
    #region "Fields"
    private CancellationTokenSource? _cts;

    #endregion
    #region "Constructor"
    public FrmLoginView()
    {
        InitializeComponent();
        SetColorUI();
    }
    #endregion
    #region "Form Events"
    private void FrmLoginView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para login.", MessageType.Information);
    }
    #endregion
    #region "Methods"
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelLineButtom.BackColor = AppColors.Outline;
        PanelLineTop.BackColor = AppColors.Outline;

        PanelButtom.BackColor = AppColors.Primary;

        //Buttons icon color
        IconPictureBoxLogin.IconColor = AppColors.Secondary;
        BtnLogin.IconColor = AppColors.Secondary;


        //Buttons text color 
        BtnLogin.ForeColor = AppColors.OnSurface;

        LabelCompanyName.ForeColor = AppColors.OnPrimary;

    }
    private void ClearMessageErr()
    {
        errorProvider1.Clear();

        if (LabelAlertMessage.Text.Contains("Formulario"))
        {
            return;
        }

        SetMessage("Formulario preparado para login.", MessageType.Information);
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
                onCountdownFinished: () => SetMessage("Formulario preparado para login.", MessageType.Information));

            // Inicia la cuenta establecida en CountdownTimer y espera
            await countdown.StartAsync(_cts!.Token);
        }
        catch (OperationCanceledException)
        {
            // Captura la cancelación del temporizador
            SetMessage("Formulario preparado para login.", MessageType.Information);

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

    #endregion 
    #region "Field and Btn Events"
    private void TextBoxEmail_TextChanged(object sender, EventArgs e)
    {

    }

    private void TextBoxPassword_TextChanged(object sender, EventArgs e)
    {

    }

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;

        this.Close();
    }
    #endregion
}
