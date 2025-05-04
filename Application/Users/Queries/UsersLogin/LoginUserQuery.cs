using ApplicationLayer.ACommen.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Queries.UsersLogin
{
    public class LoginUserQuery : IRequest<string>
    {
        public LoginUserQuery(UserCredentialsDto loginUser)
        {
            LoginUser = loginUser;
        }

        public UserCredentialsDto LoginUser { get; }
    }
}
