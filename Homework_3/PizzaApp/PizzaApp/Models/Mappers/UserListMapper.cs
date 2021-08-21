using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.Mappers
{
    public static class UserListMapper
    {
        public static UserListViewModel UserToUserListModelView(User user)
        {
            return new UserListViewModel
            {
                Id = user.Id,
                UserFullName = $"{user.FirstName} {user.LastName}"
            };
        }
    }
}
