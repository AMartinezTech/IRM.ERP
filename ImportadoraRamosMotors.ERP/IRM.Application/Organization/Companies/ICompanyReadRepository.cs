using IRM.Core.Interfaces;
using IRM.Core.Organization.Companies;

namespace IRM.Application.Organization.Companies;

public interface ICompanyReadRepository : IFilter<CompanyEntity>, IGetById<CompanyEntity, Guid>
{
    Task<bool> ExistsAsync(string rnc);
}
