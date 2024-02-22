/* ----------------------------------------------------------- Start of the code -----------------------------------------------------------*/
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

namespace PiTimeSolution.StartUP 
{
/**
*
* @studentName EmmanuelKianda
* @studentNumber 10081944
* @PROG6212
* @Part 2
*/
    /// <summary>
    /// Interaction logic for authoriseUser.xaml
    /// </summary>
    public partial class authoriseUser : Window
    {
        public authoriseUser()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // Code to control the direction of the mouse
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; // Code to minimize the window
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Code to shut down the application
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Closing current window
            StartUP.loginUI login = new StartUP.loginUI(); // Creating object for {loginUI}
            login.Show();// Opening {loginUI}
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Closing current window
            StartUP.registerUI register = new StartUP.registerUI(); // Creating object for {registerUI}
            register.Show();// Opening {registerUI}
        }
    }
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/
