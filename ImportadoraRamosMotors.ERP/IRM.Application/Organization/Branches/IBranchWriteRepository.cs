using IRM.Core.Interfaces;
using IRM.Core.Organization.Branches;

namespace IRM.Application.Organization.Branches;

public interface IBranchWriteRepository : ICreate<BranchEntity>, IUpdate<BranchEntity>;