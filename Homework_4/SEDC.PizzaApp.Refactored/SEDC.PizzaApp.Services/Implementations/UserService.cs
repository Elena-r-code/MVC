using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.UserViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository) 
        {
            _userRepository = userRepository;
        }

        public List<UserDDViewModel> GetUsersForDropdown()
        {
            
            List<User> usersDb = _userRepository.GetAll();
            
            return usersDb.Select(x => x.ToUserDDViewModel()).ToList();
        }
    }
}
