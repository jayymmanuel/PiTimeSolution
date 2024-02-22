/* ----------------------------------------------------------- Start of the code -----------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for loginUI.xaml
    /// </summary>
    public partial class loginUI : Window
    {
        static string cUsername;
        static string cPassword;

        public static string CUsername { get => cUsername; set => cUsername = value; }
        public static string CPassword { get => cPassword; set => cPassword = value; }

        public loginUI()
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

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            // Storing textboxes values into variables
             CUsername = txtUsername.Text;
             CPassword = txtPassword.Password;


                DbController controlla = new DbController(); // Creating Object to reference DbController

            if (controlla.accessCredentials()) // If statement to determine whether the User's details exist within the database
            {


                MessageBox.Show("Successfully logged in", "Welcome", MessageBoxButton.OK, MessageBoxImage.Information); // Notifying user that data has been saved 

                this.Close(); // Closing current window
                u1.HomePage.HomePage HomeWin = new u1.HomePage.HomePage(); // Initiating {HomePage}
                HomeWin.Show();// Opening {HomePage}
            }

            else
            {
                MessageBox.Show("Username or Password entered is incorrect or Account doesn't exist", "", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }


        private void btnForgotpw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Closing current window
            authoriseUser startUp = new authoriseUser(); // Initiating {authoriseUser}
            startUp.Show();// Opening {authoriseUser}
        }



    }
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/
