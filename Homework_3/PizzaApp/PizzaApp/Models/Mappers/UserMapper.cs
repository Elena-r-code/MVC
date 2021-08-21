using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.Mappers
{
    public static class UserMapper
    {
        public static UserDetailsViewModel UserToUserDetailsViewModel(this User user, User userList)
        {
            return new UserDetailsViewModel{
                UserFullName = $"{userList.FirstName} {userList.LastName}",
                    UserAddress = userList.Address
            };
        }
    }
}
