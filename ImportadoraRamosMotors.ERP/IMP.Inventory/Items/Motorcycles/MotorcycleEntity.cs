using IRM.Core.BaseEntities;
using IRM.Core.Enums;
using IRM.Core.Exceptions;

namespace IRM.Core.Inventory.Items.Motorcycles;

public class MotorcycleEntity : EntityBase
{

    public Guid Brand { get; private set; }
    public Guid Model { get; private set; }
    public Guid Color { get; private set; }
    public int Year { get; private set; }
    public MotocicleCondition Condition { get; private set; }  // New, SemiNew, Used
    public bool IsImported { get; private set; }
    public int EngineDisplacement { get; private set; } // CC (Ej: 125)
    public MotorcycleUnitEntity MotorcycleUnit { get; private set; }

    private MotorcycleEntity(Guid brand, Guid model, Guid color, int year, MotocicleCondition condition, bool isImported, int engineDisplacement)
    {
        Id = Guid.NewGuid();

        Brand = brand;
        Model = model;
        Color = color;
        Year = year;
        Condition = condition;
        IsImported = isImported;
        EngineDisplacement = engineDisplacement;

        Validate();
    }
    public static MotorcycleEntity Create(Guid brand, Guid model, Guid color, int year, MotocicleCondition condition, bool isImported, int engineDisplacement)
    {
        return new MotorcycleEntity(brand, model, color, year, condition, isImported, engineDisplacement);
    }
    public void AddMotocicleUnit(MotorcycleUnitEntity motorcycleUnit)
    {
        MotorcycleUnit = motorcycleUnit;
    }
    public override void Validate()
    {
        if (Brand == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "MARCA")} - {nameof(Brand)}");

        if (Model == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "MODELO")} - {nameof(Model)}");

        if (Color == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "COLOR")} - {nameof(Color)}");

        if (Year <= 0)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "AÑO")} - {nameof(Year)}");

        if (EngineDisplacement <= 0)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "CILINDRAJE")} - {nameof(EngineDisplacement)}");
    }

    public void Update(Guid brand, Guid model, Guid color, int year, MotocicleCondition condition, bool isImported, int engineDisplacement)
    {
        Brand = brand;
        Model = model;
        Color = color;
        Year = year;
        Condition = condition;
        IsImported = isImported;
        EngineDisplacement = engineDisplacement;
        Validate();
    }

    public override void MarkAsActive() => IsActive = true;

    public override void MarkAsInactive() => IsActive = false;
}
