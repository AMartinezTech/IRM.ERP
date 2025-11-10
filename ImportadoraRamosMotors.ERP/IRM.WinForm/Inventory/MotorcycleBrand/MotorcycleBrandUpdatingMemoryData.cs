using IRM.Application.Inventory.Items.MotorcycleBrand; 
using System.ComponentModel;

namespace IRM.WinForm.Inventory.MotorcycleBrand;

internal class MotorcycleBrandUpdatingMemoryData
{
    internal static BindingList<MotorcycleBrandDto> Excecute(MotorcycleBrandDto dto, BindingList<MotorcycleBrandDto> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
            item.Name = dto.Name;
            item.IsActive = dto.IsActive;
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
