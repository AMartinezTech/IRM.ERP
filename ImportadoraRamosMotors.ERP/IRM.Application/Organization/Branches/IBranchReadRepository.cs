using IRM.Core.Interfaces;
using IRM.Core.Organization.Branches;

namespace IRM.Application.Organization.Branches;

public interface IBranchReadRepository : IFilter<BranchEntity>, IGetById<BranchEntity, Guid>
{
    Task<bool> ExistsAsync(Guid companyId, string name);
}
