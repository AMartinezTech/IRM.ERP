using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IRM.WinForm.Utils;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        return value.GetType()
                    .GetField(value.ToString())
                    ?.GetCustomAttribute<DisplayAttribute>()?
                    .GetName()
                    ?? value.ToString(); 
    }
}

// IMPLEMENTATION
//var statuses = Enum.GetValues(typeof(MotorcycleUnitStatusEnum))
//    .Cast<MotorcycleUnitStatusEnum>()
//    .Select(e => new
//    {
//        Value = e,
//        Text = e.GetDisplayName()
//    })
//    .ToList();

//comboBoxStatus.DataSource = statuses;
//comboBoxStatus.DisplayMember = "Text";
//comboBoxStatus.ValueMember = "Value";