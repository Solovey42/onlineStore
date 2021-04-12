using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
