using SkiServcieWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServcieWPF.Stores
{
    public class LoginStore
    {
        public event Action<UserLoginData> UserTokenCreated;
        
        public void CreateUserData(UserLoginData userToken)
        {
            UserTokenCreated?.Invoke(userToken);
        }
    }
}
