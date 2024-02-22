/* ----------------------------------------------------------- start of the code -----------------------------------------------------------*/
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
using System.IO;
using System.Data;
using System.Threading;

namespace PiTimeSolution.u6.Summary
/**
*
* @studentName EmmanuelKianda
* @studentNumber 10081944
* @PROG6212
* @Part 2
*/
{
    /// <summary>
    /// Interaction logic for Summary.xaml
    /// </summary>
    public partial class Summary : Window
    {


        // Declaring Global variables
        static double remainingHours;
        static double currentSelection;
        static double hoursStudied;


        public static double RemainingHours { get => remainingHours; set => remainingHours = value; }
        public static double CurrentSelection { get => currentSelection; set => currentSelection = value; }
        public static double HoursStudied { get => hoursStudied; set => hoursStudied = value; }

        DbController controlla = new DbController();

        public Summary()
        {

            InitializeComponent();

            // For loop to iterate throught every List
            for (int i = 0; i < 1; i++)
            {


                string theModule = u5.Capture.CaptureStudy.CsModuleCode.ToString(); // Getting the Module selected by user



                // LINQ query
                // Finding the corresponding Module self study hours required
                var findStudy = from s in u4.Analytics.ModuleAnalytics.StudyDetails
                                where s.selectedModule == theModule
                                select s.userSelfStudy;



                foreach (double item in findStudy) // Foreach loop will  to loop through the findStudy variable to get the answer
                {
                    currentSelection = item; // Storing item inside the currentSelection 
                }


                // Formula to solve the remaining hours
                hoursStudied = u5.Capture.CaptureStudy.CsHoursStudied;
                remainingHours = currentSelection - hoursStudied; // Calculating the remaing hours

                // Displaying summary/report 
                txtSummary.Text += "Module Code : " + u5.Capture.CaptureStudy.CsModuleCode // Retrieving selected Module from Interface 5
                    + "\n" + "Self study hours required: " + String.Format("{0:0.00}", currentSelection)
                    + "\n" + "Hours studied: " + hoursStudied
                    + "\n" + "Remaing hours: " + String.Format("{0:0.00}", remainingHours) + "\n";


            }

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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            // if statement if user hasn't chosen to store their data


            this.Hide(); // Closing current window
            u1.HomePage.HomePage winHome = new u1.HomePage.HomePage(); // Creating object for {HomePage}
            winHome.Show();// Opening {HomePage}


        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Closing current window 
            u5.Capture.CaptureStudy winCapture = new u5.Capture.CaptureStudy(); // Creating object for {CaptureStudy}
            winCapture.Show(); //  Opening {CaptureStudy}
        }


        private void btnStore_Click(object sender, RoutedEventArgs e)
        {
            DbController controller = new DbController();

            if (controlla.uniqueModule()) // If statement which checks whether the specified modules is unique
            {

                storeDataThread(); // Executing Threads


                MessageBoxResult alert = MessageBox.Show(this, "Would you like to save another one?", "Store Module", // Notifying user
    MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (alert == MessageBoxResult.Yes) // If User selects the "Yes" button
                {
                    this.Hide();
                    u5.Capture.CaptureStudy capture = new u5.Capture.CaptureStudy(); // Creating object to reference {CaptureStudy}
                    capture.Show(); // Opening {CaptureStudy}
                }
                else if (alert == MessageBoxResult.No) // If User selects the "No" button
                {
                    this.Hide(); // Closing current window
                    u1.HomePage.HomePage winHome = new u1.HomePage.HomePage(); // Creating object for {HomePage}
                    winHome.Show();// Opening {HomePage}
                }
            }
            else
            {
                MessageBoxResult alert = MessageBox.Show("This Module details' have already been saved,", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (alert == MessageBoxResult.OK)
                {
                    // Nothing is triggered within the application.
                }
            }

        }

        //------------------------------------------IMPLEMENTING THREADING----------------------------------------------------
        public void storeDataThread()
        {
            // Creating Threads that execute simultaneously
            Thread storeThread = new Thread(new ThreadStart(inputData)); // Creating 1st Thread
            storeThread.Start(); // Starting 1st Thread

            Thread notifyThread = new Thread(new ThreadStart(notifyUser)); // Creating 2nd Thread
            notifyThread.Start(); // Starting 2nd Thread
        }

        public void inputData()
        {
            DbController controller = new DbController(); // Creating Object to reference DbController Class
            controller.storeModuleProgress(); // Invoking Class responsible for storing Module Details
        }

        public void notifyUser()
        {
            MessageBox.Show("Module details have been saved", "Saved", // Notifying user
            MessageBoxButton.OK, MessageBoxImage.Information);

        }
        //------------------------------------------END OF THREADS----------------------------------------------------


    }
}
/* -------------------------------------------------------------------------- end of the code --------------------------------------------------------------------------*/

