/* ----------------------------------------------------------- Start of the code -----------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using CalculateLibrary;


namespace PiTimeSolution.u4.Analytics

/**
*
* @studentName EmmanuelKianda
* @studentNumber 10081944
* @PROG6212
* @Part 2
*/
{
    /// <summary>
    /// Interaction logic for ModuleAnalytics.xaml
    /// </summary>
    public partial class ModuleAnalytics : Window
    {
        DbController controller = new DbController();
        Calculations calculate = new Calculations(); // Creating object to reference selfStudy class from CalculateLibrary

        public static List<Entry> studyDetails = new List<Entry>(); // Creating List with datatype of class Entry

        public static List<Entry> StudyDetails { get => studyDetails; set => studyDetails = value; } // Creating Getter and Setter

        private static string tempModName;
        private static string tempModCode;
        private static double tempModCredits;
        private static double tempModHours;

        public static string TempModName { get => tempModName; set => tempModName = value; }
        public static string TempModCode { get => tempModCode; set => tempModCode = value; }
        public static double TempModCredits { get => tempModCredits; set => tempModCredits = value; }
        public static double TempModHours { get => tempModHours; set => tempModHours = value; }

        public ModuleAnalytics()
        {
            InitializeComponent();

            string module; // Creating variable

            // Emptying textbox
            txtList.Text = "";




            for (int i = 0; i < u3.Store.storeModule.entryDetails.Count; i++) // For loop for each element stored in the entryDetails list (from MainWindow) that iterates
                                                                     // through the variables needed to calculate the required self-study hours.
            {

                double selfStudyHours = 0; // Declaring variable

                double w = u3.Store.storeModule.entryDetails[i].moduleCredits; // Iterating through all module credits
                double x = u2.Semester.ModuleSelection.StNoWeeksInSem; // Fetching value of number of weeks in semeseter (constant variable)
                double z = u3.Store.storeModule.entryDetails[i].classHrsWeekly; // Iterating through all class hours per week

                tempModName = u3.Store.storeModule.entryDetails[i].moduleName;
                tempModCode = u3.Store.storeModule.entryDetails[i].moduleCode;
                tempModCredits = u3.Store.storeModule.entryDetails[i].moduleCredits;
                tempModHours = u3.Store.storeModule.entryDetails[i].classHrsWeekly;


                selfStudyHours = calculate.selfStudy(w, x, z);

                // Displaying Module Information
                txtList.Text += "Module Code : " + u3.Store.storeModule.entryDetails[i].moduleCode + "\n" + "Self study hours required: " + String.Format("{0:0.00}", selfStudyHours) + "\n\n";
                module = u3.Store.storeModule.entryDetails[i].moduleCode;

                // Storing module details inside List
                studyDetails.Add(new Entry()
                {
                    selectedModule = module,
                    userSelfStudy = selfStudyHours,



                }

                    );




                DbController controlla = new DbController();  // Creating Object to reference DbController

                controlla.storeModuleDetails(); // Invoking the method responsible to store module details

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
            this.Hide(); // Closing current window
            u1.HomePage.HomePage HomeWin = new u1.HomePage.HomePage(); // Creating object for {HomePage}
            HomeWin.Show();// Opening {HomePage}
        }



    }
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/

