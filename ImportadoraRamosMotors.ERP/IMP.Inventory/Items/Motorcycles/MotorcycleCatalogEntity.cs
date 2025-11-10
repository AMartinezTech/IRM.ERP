using IRM.Core.BaseEntities;
using IRM.Core.Enums;
using IRM.Core.Exceptions;
using IRM.Core.Shared.Utils;
using System;

namespace IRM.Core.Inventory.Items.Motorcycles;

public class MotorcycleCatalogEntity : EntityBase
{
    public Guid BrandId { get; private set; }
    public Guid ModelId { get; private set; }
    public Guid ColorId { get; private set; }
    public int Year { get; private set; }
    public MotorcycleCondition Condition { get; private set; }  // New, SemiNew, Used 
    public int EngineDisplacement { get; private set; } // CC (Ej: 125)
    private readonly List<MotorcycleEntity> _motorcycles = [];
    public IReadOnlyCollection<MotorcycleEntity> Motorcycles => _motorcycles.AsReadOnly();

    private MotorcycleCatalogEntity(Guid id,Guid brandId, Guid modelId, Guid colorId, int year, MotorcycleCondition condition, int engineDisplacement)
    {
        Id = id; 
        BrandId = brandId;
        ModelId = modelId;
        ColorId = colorId;
        Year = year;
        Condition = condition;
        EngineDisplacement = engineDisplacement;

        Validate();
    }
    public static MotorcycleCatalogEntity Create(Guid id, Guid brandId, Guid modelId, Guid colorId, int year, string condition, int engineDisplacement)
    {

        if (!Enum.TryParse(condition, true, out MotorcycleCondition resultCondition))
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "CONDICIÓN")} - {nameof(Condition)}");

        return new MotorcycleCatalogEntity(GuidID.Generate(id), brandId, modelId, colorId, year, resultCondition, engineDisplacement);
    }
    public void AddMotorcycleUnit(MotorcycleEntity motorcycleUnit)
    {
        if (motorcycleUnit == null)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "MOTOCICLETA")} - {nameof(MotorcycleEntity)}");

        _motorcycles.Add(motorcycleUnit);
    }

    public void RemoveMotorcycle(Guid motorcycleId)
    {
        var unit = _motorcycles.FirstOrDefault(x => x.Id == motorcycleId)
            ?? throw new ValidationException($"La unidad con Id {motorcycleId} no existe en este catálogo.");

        _motorcycles.Remove(unit);
    }
    public override void Validate()
    {
        if (BrandId == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "MARCA")} - {nameof(BrandId)}");

        if (ModelId == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "MODELO")} - {nameof(ModelId)}");

        if (ColorId == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "COLOR")} - {nameof(ColorId)}");

        if (Year <= 0)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "AÑO")} - {nameof(Year)}");

        if (EngineDisplacement <= 0)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "CILINDRAJE")} - {nameof(EngineDisplacement)}");
    }
    public void EnsureCanBeDeleted()
    {
        if (_motorcycles.Count != 0)
            throw new ValidationException($"{string.Format(CommonErrors.CannotBeDeletedHasMovement, "LA MOTOCICLETA")}");
    }

    public void Update(Guid brandId, Guid modelId, Guid colorId, int year, string condition,  int engineDisplacement)
    {
        if (!Enum.TryParse(condition, true, out MotorcycleCondition resultCondition))
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "CONDICIÓN")} - {nameof(Condition)}");
        if (_motorcycles.Count != 0)
            throw new ValidationException($"{string.Format(CommonErrors.CannotBeModifiedHasMovement, "LA MOTOCICLETA")}");

        BrandId = brandId;
        ModelId = modelId;
        ColorId = colorId;
        Year = year;
        Condition = resultCondition; 
        EngineDisplacement = engineDisplacement;
        Validate();
    }


}
