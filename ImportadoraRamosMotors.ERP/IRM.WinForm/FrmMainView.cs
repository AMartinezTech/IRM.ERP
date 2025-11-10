using IRM.WinForm.Inventory;
using IRM.WinForm.Utils;
using IRM.WinForm.Utils.Factories;

namespace IRM.WinForm;

public partial class FrmMainView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    private Form _childContainerForm;
    private Form _childLeftMenuForm;
    #endregion
    public FrmMainView(IFormFactory formFactory)
    {
        InitializeComponent();
        _formFactory = formFactory;
        SetColorUI();
    }

    private void FrmMainView_Load(object sender, EventArgs e)
    {

    }

    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelMainMenu.BackColor = AppColors.SurfaceVariant;
        PanelTopLine.BackColor = AppColors.Primary;
        PanelButtomLine.BackColor = AppColors.Outline;
        PanelContainer.BackColor = AppColors.Surface;
        PanelButtomMenu.BackColor = AppColors.Primary;

        //Buttons icon color
        BtnInventory.IconColor = AppColors.Primary;
        BtnPurcharsing.IconColor = AppColors.Primary;
        BtnOrganization.IconColor = AppColors.Primary;

        //Buttons text color 
        BtnInventory.ForeColor = AppColors.OnSurface;
        BtnPurcharsing.ForeColor = AppColors.OnSurface;
        BtnOrganization.ForeColor = AppColors.OnSurface;

        //Label text color
        LabelWelcome.ForeColor = AppColors.OnPrimary;
    }
    private void OpenChildFormContainer(Form childForm)
    {
        //Main form
        _childContainerForm?.Close();
        _childContainerForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        PanelContainer.Controls.Add(childForm);
        PanelContainer.Tag = childForm;
        childForm.BringToFront();
        childForm.Show();

    }

    private void OpenChildFormMenu(Form childForm)
    {
        //Main form
        _childLeftMenuForm?.Close();
        _childLeftMenuForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        PanelLeftMenu.Controls.Add(childForm);
        PanelLeftMenu.Tag = childForm;
        childForm.BringToFront();
        childForm.Show();

    }

    private void BtnInventory_Click(object sender, EventArgs e)
    {
        var frmInventoryMainView = _formFactory.CreateFormFactory<FrmInventoryMainView>();
        OpenChildFormContainer(frmInventoryMainView);

        var frmInventoryLeftMenu = _formFactory.CreateFormFactory<FrmInventoryLeftMenuView>();
        OpenChildFormMenu(frmInventoryLeftMenu);
    }
}
