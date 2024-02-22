/* ----------------------------------------------------------- Start of the code -----------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for registerUI.xaml
    /// </summary>
    public partial class registerUI : Window
    {
        // Creating Global variables
        private string stUsername;
        private string stPassword;


        public DbController controller = new DbController();

        public registerUI()
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

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
             Thread processRegistration = new Thread(registerUser); // Thread responsible for saving user input into the Database


            if (ValidateCredentials()) // If statement to determine whether the User's input is valid based on the requirements
            {
                
                Student student = new Student(stUsername, stPassword);

                if (controller.uniqueUser(student)) // If statement to determine whether the User's input details don't already exist within the database
                {


                    MessageBox.Show("Welcome! to PI.TIME" , "Access granted", MessageBoxButton.OK, MessageBoxImage.Information); // Displaying welcome message

                    processRegistration.Start();

                    this.Hide(); // Closing current window
                    u1.HomePage.HomePage HomeWin = new u1.HomePage.HomePage(); // Initiating {HomePage}
                    HomeWin.Show();// Opening {HomePage}
                }
                else
                {
                    MessageBoxResult alert = MessageBox.Show("Account already exist, please log in " , "Warning Message", MessageBoxButton.OK, MessageBoxImage.Error); // Notifying user

                    if (alert == MessageBoxResult.OK)
                    {
                        // Clearing textboxes
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtConfirm.Clear();
                    }
                }



                

            }
            else
            {
                // Error messageBoxes will be displayed to the User
            }
        }

        private bool ValidateCredentials()
        {
            bool isValid = true; // Creating boolean variable

            // Validating username entered 
            if (txtUsername.Text.Length < 8 || txtUsername.Text.Length > 30)
            {
                isValid = false;
                MessageBox.Show(this, "Username  must be between 8 to 30 characters too long." + "\n", "Invalid Input", // Notifying user
MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
            else
            {
               stUsername = txtUsername.Text; // Storing valid input
            }

            if (txtPassword.Password.Length < 8 || txtPassword.Password.Length > 60)
            {
                isValid = false; // passwords not long enough match

                MessageBox.Show(this, "Password  must be between 8 to 60 characters too long." + "\n", "Invalid Input", // Notifying user
MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            }
            else
            {
                // Apllication proceeds
            }

            // Validating if passwords match
            if (!txtPassword.Password.Equals(txtConfirm.Password))
            {
                isValid = false; // passwords have to match
                MessageBox.Show(this, "Passwords do not match, re-enter input correctly." + "\n", "Invalid Input", // Notifying user
MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                txtConfirm.Clear();

            }
            else
            {
                stPassword = txtPassword.Password; // Storing valid input


            }


            return isValid; // Return output of boolean

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Closing current window
            authoriseUser startUp = new authoriseUser(); // Initiating {authoriseUser}
            startUp.Show();// Opening {authoriseUser}
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Closing current window
            loginUI login = new loginUI(); // Initiating {loginUI}
            login.Show();// Opening {loginUI}
        }


        public void registerUser()
        {
            Student student = new Student(stUsername, stPassword);

            controller.TransferToDB(student);
        }


    }
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/
