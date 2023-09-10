using GymHelper.DAL.Entities;
using GymHelper.DAL.Repositories.Base;

namespace GymHelper.DAL.Repositories.Interfaces;

public interface IUserRepository : IRepository<User, string>
{
    public Task<User?> FindByLoginAsync(string login);
}