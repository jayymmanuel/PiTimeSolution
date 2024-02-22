/* ----------------------------------------------------------- Start of the code -----------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace PiTimeSolution.u3.Store
/**
*
* @studentName EmmanuelKianda
* @studentNumber 10081944
* @PROG6212
* @Part 2
*/
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class storeModule : Window
    {
        // Creating Global Variables
        static int moduleLimit = 0;
        static int moduleCounter = 1;
        static int savedData = 0;

        // -- Creating List to store module details
        public static List<Entry> entryDetails = new List<Entry>();

        // Creating Getters and Setters
        public static int SavedData { get => savedData; set => savedData = value; }
        public static int ModuleLimit { get => moduleLimit; set => moduleLimit = value; }
        public static int ModuleCounter1 { get => moduleCounter; set => moduleCounter = value; }

        public storeModule()
        {
            InitializeComponent();

            ModuleCounter.Content = "Module Number  " + moduleCounter; // Displaying the Module counter

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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {


            if (ValidateInput())
            {

                moduleLimit++; // Incrementing by 1

                function(); // Method to add data

                clean(); // Method to clear textboxes
                //--------------------------- CHECKING IF NUMBER OF MODULES SPECIFIED HAS BEEN REACHED-----------------------------------------------
                if (u2.Semester.ModuleSelection.StModuleAmount == moduleLimit) // Checking if the entered amount of modules matches the module limit
                {
                    ModuleCounter.Content = "Modules Saving....  "; //Removing module counter and showcasing modules are being saved
                    savedData = 1;
                    MessageBoxResult alert = MessageBox.Show(this, "All modules have been saved", "Message", // Notifying user
        MessageBoxButton.OK, MessageBoxImage.Information);

                    if (alert == MessageBoxResult.OK) // If User selects the "Yes" button
                    {
                        this.Hide(); // Closing current window
                        SavedWindow saveWin = new SavedWindow(); // Creating object to reference {SavedWindow}
                        saveWin.Show(); // Opening {SavedWindow}
                    }

                }
                //-------------------------------------------------------------------------------------------------------------------------------------
            }
            else
            {
                // Appropriate Error messagebox will be displayed to user
            }





        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult alert = MessageBox.Show(this, "Are you sure you want to return to Home Page, all current data will be erased", "Invalid Input", // Notifying user
MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (alert == MessageBoxResult.OK)
            {
                // Resetting variables to original value
                u1.HomePage.HomePage.EmptyEntry = 0;
                moduleLimit = 0;
                moduleCounter = 1;

                // Clearing all (possibilly) stored data

                entryDetails.Clear();


                this.Close(); // Closing current window
                u1.HomePage.HomePage HomeWin = new u1.HomePage.HomePage(); // Initiating {HomePage}
                HomeWin.Show();// Opening {HomePage}
            }
            else if (alert == MessageBoxResult.Cancel)
            {
                // Application goes on 
            }


        }

        private void function()
        {

            // Storing module details inside List
            entryDetails.Add(new Entry()
            {
                moduleCode = txtModuleCode.Text, 
                moduleName = txtModuleName.Text,
                moduleCredits = double.Parse(txtCredits.Text), 
                classHrsWeekly = double.Parse(txtClassHrsWeekly.Text),



            }

                );

            moduleCounter++; // Incrementing by 1


        }

        private void clean()
        {
            // Emptying textboxes 
            txtModuleCode.Text = "";
            txtModuleName.Text = "";
            txtCredits.Text = "";
            txtClassHrsWeekly.Text = "";


            // Displaying current value of module counter
            ModuleCounter.Content = "Module Number  " + moduleCounter;
        }


        private bool ValidateInput()
        {
            bool isValid = true;

            // Validating username entered 
            if (txtModuleCode.Text.Length > 20 || txtModuleCode.Text.Equals("") || txtModuleCode.Text.Length < 4)
            {
                isValid = false;

                MessageBox.Show(this, "Module Code must be between 4 to 20 characters too long." + "\n", "Invalid Input", // Notifying user
MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            }
            else
            {
                // Application proceeds
            }

            // Validating if passwords match
            if (txtModuleName.Text.Length > 35 || txtModuleCode.Text.Equals("") || txtModuleName.Text.Length < 4)
            {
                isValid = false; // passwords have to match

                MessageBox.Show(this, "Module name must be between 4 to 35 characters. " + "\n" + "\n", "Invalid Input", // Notifying user
MessageBoxButton.OKCancel, MessageBoxImage.Warning);


            }
            else
            {
                // Application proceeds
            }

            if (!txtCredits.Text.Any(ch => Char.IsDigit(ch)) || txtCredits.Text.Equals(""))
            {
                isValid = false;


                MessageBox.Show(this, "Module credits must be entered in digit format." + "\n" + "\n", "Invalid Input", // Notifying user
MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            }
            else
            {
                // Application proceeds

            }

            if (!txtClassHrsWeekly.Text.Any(ch => Char.IsDigit(ch)) || txtClassHrsWeekly.Text.Equals(""))
            {
                isValid = false;

                MessageBox.Show(this, "Class hours must be entered in digit format." + "\n" + "\n" + "\n", "Invalid Input", // Notifying user
MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            }
            else
            {
                // Application proceeds
            }


            return isValid; // Returning boolean variable

        }


    }
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/

