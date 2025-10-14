using IRM.Core.Interfaces;
using IRM.Core.Organization.Companies;

namespace IRM.Application.Organization.Companies;

public interface ICompanyWriteRepository : ICreate<CompanyEntity>, IUpdate<CompanyEntity>;
