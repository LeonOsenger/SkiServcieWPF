using SkiServcieWPF.Model;
using SkiServcieWPF.Stores;
using SkiServcieWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServcieWPF.Commands
{
    public class CreateUserLoginDataCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly LoginStore _loginStore;

        public CreateUserLoginDataCommand(LoginViewModel viewModel, LoginStore loginStore)
        {
            _viewModel = viewModel;
            _loginStore = loginStore;
        }

        public override void Execute(object parameter)
        {
            UserLoginData userLoginData = new UserLoginData()
            {
                userName = _viewModel.UserToken.userName,
                token = _viewModel.UserToken.token,
                IsLoggedIn = _viewModel.IsLoggedIn
            };

            _loginStore.CreateUserData(userLoginData);
        }
    }
}
