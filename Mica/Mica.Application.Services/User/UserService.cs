using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mica.Application.Services.Abstract.User;

namespace Mica.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserService(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        public IList<SelectListItem> GetForPickup()
        {
            var queryableResult = this._userManager.Users
                                    .AsNoTracking()
                                    .OrderBy(m => m.UserName)
                                    .Select(m => new SelectListItem
                                    {
                                        Text = m.UserName,
                                        Value = m.Id.ToString()
                                    });

            return queryableResult.ToList();
        }
    }
}
