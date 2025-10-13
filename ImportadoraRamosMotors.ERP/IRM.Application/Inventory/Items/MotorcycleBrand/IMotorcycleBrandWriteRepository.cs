using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleBrand;

public interface IMotorcycleBrandWriteRepository : ICreate<MotorcycleBrandEntity>, IUpdate<MotorcycleBrandEntity>, IDelete<MotorcycleBrandEntity,Guid>;