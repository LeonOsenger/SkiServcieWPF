using SkiServcieWPF.Stores;
using SkiServcieWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SkiServcieWPF.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        public Login(LoginStore login)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            DataContext = new LoginViewModel(login);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is ICloseWindow vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
