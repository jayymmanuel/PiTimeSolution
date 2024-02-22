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

namespace PiTimeSolution.u2.Semester
/**
*
* @studentName EmmanuelKianda
* @studentNumber 10081944
* @PROG6212
* @Part 2
*/
{
    /// <summary>
    /// Interaction logic for ModuleSelection.xaml
    /// </summary>
    public partial class ModuleSelection : Window
    {
        // Creating Global Variables
        static double stModuleAmount;
        static double stModuleCounter;
        static string stSemStartDt;
        static double stNoWeeksInSem;



        // Creating Getters and Setters
        public static double StModuleAmount { get => stModuleAmount; set => stModuleAmount = value; }
        public static double StModuleCounter { get => stModuleCounter; set => stModuleCounter = value; }
        public static string StSemStartDt { get => stSemStartDt; set => stSemStartDt = value; }

        public static double StNoWeeksInSem { get => stNoWeeksInSem; set => stNoWeeksInSem = value; }



        public ModuleSelection()
        {
            InitializeComponent();

            // Clearining Lists for every instance the User chooses to store a new Semester entry
            u3.Store.storeModule.entryDetails.Clear();
            u4.Analytics.ModuleAnalytics.studyDetails.Clear();
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

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // Creating Local Variable
            bool correctInput = false;

            // Creating While loop to prompt the user until they enter valid input
            while (correctInput == false)
            {
                try
                {
                    // Storing user's input from textboxes into variables
                    StModuleAmount = double.Parse(amountOfModules.Text);
                    StNoWeeksInSem = double.Parse(txtNumberOfWeeks.Text);
                    stSemStartDt = txtSemesterStartDt.Text;




                        this.Hide(); // Closing current window
                        u3.Store.storeModule storeWin = new u3.Store.storeModule(); // Creating object for {MainWindow}
                    storeWin.Show();// Opening {MainWindow}
                    correctInput = true; // Setting the correctInput as true to allow the user to exit the While Loop.

                    

                }

                catch (FormatException) // Error Handling
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    MessageBoxResult alert = MessageBox.Show(this, "Please answer all fields correctly", "Invalid Input", //Notifying user
                        MessageBoxButton.OK, MessageBoxImage.Error);

                    if (alert == MessageBoxResult.OK)
                    {
                        this.Hide(); // Closing current window
                    }
                    correctInput = true;  // Setting the correctInput as true to allow the user to exit the While Loop.
                    ModuleSelection SelectWin = new ModuleSelection(); // Creating object to reference {HomeLoanWindow2}
                    SelectWin.Show(); // Opening {HomeLoanWindow2}


                }


            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult alert = MessageBox.Show(this, "Are you sure you want to return to Home Page, all current data will be erased", "Invalid Input", // Notifying user
MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (alert == MessageBoxResult.OK)
            {


                this.Close(); // Closing current window
                u1.HomePage.HomePage HomeWin = new u1.HomePage.HomePage(); // Creating object for {HomePage}
                HomeWin.Show();// Opening {HomePage}
            }
            else if (alert == MessageBoxResult.Cancel)
            {
                // Application goes on 
            }
        }
    }
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/
