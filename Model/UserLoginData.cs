using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServcieWPF.Model
{
    public class UserLoginData
    {
        public string userName { get; set; }

        public string token { get; set; }

        public bool IsLoggedIn { get; set; }
    }
}
