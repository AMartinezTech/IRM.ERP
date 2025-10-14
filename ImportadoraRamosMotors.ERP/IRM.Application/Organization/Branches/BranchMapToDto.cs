using IRM.Core.Organization.Branches;

namespace IRM.Application.Organization.Branches;

internal class BranchMapToDto
{
    internal static BranchDto Single(BranchEntity entity)
    {
        return new BranchDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Address = entity.Address,
            Email = entity.Email,
            Phone = entity.Phone,
            CompanyId = entity.CompanyId,
            IsActive = entity.IsActive,
        };
    }

    internal static List<BranchDto> List(IEnumerable<BranchEntity> entities)
    {
        return [.. entities.Select(Single)];
    }
}
