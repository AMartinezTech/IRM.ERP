using IRM.Application.Inventory.Items.MotorcycleModel;
using System.ComponentModel;

namespace IRM.WinForm.Inventory.MotorcycleModel;

internal class MotorcycleModelUpdatingMemoryData
{
    internal static BindingList<MotorcycleModelDto> Excecute(MotorcycleModelDto dto, BindingList<MotorcycleModelDto> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
            item.Name = dto.Name;
            item.IsActive = dto.IsActive;
            item.BrandId = dto.BrandId;
        }
        else
        {
            // Si el elemento no existe, lo agregamos
            itemList.Add(dto);
        }

        // Devuelvo la lista actualizada
        return itemList;
    }
}
