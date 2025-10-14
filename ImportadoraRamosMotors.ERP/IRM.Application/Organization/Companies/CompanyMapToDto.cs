using IRM.Application.Organization.Branches;
using IRM.Core.Organization.Companies;

namespace IRM.Application.Organization.Companies;

internal class CompanyMapToDto
{
    internal static CompanyDto Single(CompanyEntity entity)
    {
        return new CompanyDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Rnc = entity.Rnc,
            Address = entity.Address,
            Email = entity.Email,
            Phone = entity.Phone,
            IsActive = entity.IsActive,
            Branches = [.. entity.Branches.Select(b => new BranchDto {
                Id = b.Id,
                Name = b.Name,
                Address = b.Address,
                Email = b.Email,
                Phone = b.Phone,
                CompanyId = b.CompanyId,
                IsActive = b.IsActive,
            })]
        };
    }

    internal static List<CompanyDto> List(IEnumerable<CompanyEntity> entities) 
    {
        return [.. entities.Select(Single)];
    }
}
