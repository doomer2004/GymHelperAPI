using GymHelper.DAL.EF;
using GymHelper.DAL.Entities;
using GymHelper.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace GymHelper.DAL.Repositories;

public class UserRepository : RepositoryBase<User>
{
    public UserRepository(Context context) : base(context)
    {
        
    }

    public async Task<User?> FindByLoginAsync(string login)
    {
        return await Table.FirstOrDefaultAsync(user => user.Login == login);
    }
}