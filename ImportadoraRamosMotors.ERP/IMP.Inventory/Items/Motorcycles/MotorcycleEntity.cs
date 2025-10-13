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
    public MotorcycleCondition Condition { get; private set; }  // New, SemiNew, Used
    public bool IsImported { get; private set; }
    public int EngineDisplacement { get; private set; } // CC (Ej: 125)
    private readonly List<MotorcycleUnitEntity> _motorcycleUnits = [];
    public IReadOnlyCollection<MotorcycleUnitEntity> MotorcycleUnits => _motorcycleUnits.AsReadOnly();
     
    private MotorcycleEntity(Guid brand, Guid model, Guid color, int year, MotorcycleCondition condition, bool isImported, int engineDisplacement)
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
    public static MotorcycleEntity Create(Guid brand, Guid model, Guid color, int year, MotorcycleCondition condition, bool isImported, int engineDisplacement)
    {
        return new MotorcycleEntity(brand, model, color, year, condition, isImported, engineDisplacement);
    }
    public void AddMotorcycleUnit(MotorcycleUnitEntity motorcycleUnit)
    {
        if (motorcycleUnit == null)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "MOTOCICLETA")} - {nameof(MotorcycleUnitEntity)}");

        _motorcycleUnits.Add(motorcycleUnit);
    }

    public void RemoveMotorcycleUnit(Guid motorcycleUnitId)
    {
        var unit = _motorcycleUnits.FirstOrDefault(x => x.Id == motorcycleUnitId) 
            ?? throw new ValidationException($"La unidad con Id {motorcycleUnitId} no existe en este catálogo.");
        
        _motorcycleUnits.Remove(unit);
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
    public void EnsureCanBeDeleted()
    {
        if (_motorcycleUnits.Count != 0)
            throw new ValidationException($"{string.Format(CommonErrors.CannotBeDeletedHasMovement, "LA MOTOCICLETA")}");
    }

    public void Update(Guid brand, Guid model, Guid color, int year, MotorcycleCondition condition, bool isImported, int engineDisplacement)
    {
        if (_motorcycleUnits.Count != 0)
            throw new ValidationException($"{string.Format(CommonErrors.CannotBeModifiedHasMovement, "LA MOTOCICLETA")}");

        Brand = brand;
        Model = model;
        Color = color;
        Year = year;
        Condition = condition;
        IsImported = isImported;
        EngineDisplacement = engineDisplacement;
        Validate();
    }

 
}
