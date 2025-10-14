using IRM.Core.Interfaces;
using IRM.Core.Organization.Users;

namespace IRM.Application.Organization.Users;

public interface IUserWriteRepository : ICreate<UserEntity>, IUpdate<UserEntity>;