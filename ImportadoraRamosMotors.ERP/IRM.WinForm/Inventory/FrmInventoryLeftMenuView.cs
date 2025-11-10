using IRM.WinForm.Inventory.Item;
using IRM.WinForm.Inventory.MotorcycleBrand;
using IRM.WinForm.Utils;
using IRM.WinForm.Utils.Factories;

namespace IRM.WinForm.Inventory;

public partial class FrmInventoryLeftMenuView : Form
{
    private readonly IFormFactory _formFactory;
    public FrmInventoryLeftMenuView(IFormFactory formFactory)
    {
        InitializeComponent();
        SetColorUI();
        _formFactory = formFactory;
    }

    private void FrmInventoryLeftMenuView_Load(object sender, EventArgs e)
    {

    }

    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;


        //Buttons icon color
        BtnColor.IconColor = AppColors.Primary;
         
        BtnBrand.IconColor = AppColors.Primary;
        BtnItem.IconColor = AppColors.Primary;
        BtnTraslateOrder.IconColor = AppColors.Primary;


        //Buttons text color 
        BtnTraslateOrder.ForeColor = AppColors.OnSurface;



    }

    private void BtnItem_Click(object sender, EventArgs e)
    {

    }

    private void BtnColor_Click(object sender, EventArgs e)
    {
        var frmItemColor = _formFactory.CreateFormFactory<FrmMotorcycleColorView>();
        frmItemColor.ShowDialog();
    }

    private void BtnBrand_Click(object sender, EventArgs e)
    {
        var frmItemBrand = _formFactory.CreateFormFactory<FrmMotorcycleBrandView>();
        frmItemBrand.ShowDialog();
    }
}
