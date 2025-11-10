using IRM.Application.Inventory.Items.MotorcycleColor;
using System.ComponentModel;

namespace IRM.WinForm.Inventory.MotorcycleColor;

internal class MotorcycleColorUpdatingMemoryData
{
    internal static BindingList<MotorcycleColorDto> Excecute(MotorcycleColorDto dto, BindingList<MotorcycleColorDto> itemList)
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
