using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Services
{
    class UsersRepository : IUserRepository
    {
        private ApplicationContext context;
        public UsersRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
