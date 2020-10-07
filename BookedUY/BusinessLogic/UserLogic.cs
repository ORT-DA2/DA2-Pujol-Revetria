using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            if (this.userRepository.GetByEmail(user.Email)==null)
            {
                var newUser = this.userRepository.Add(user);
                return newUser;
            }
            throw new AlreadyExistsException();
        }
    }
}
