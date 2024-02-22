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

namespace PiTimeSolution.u5.Capture

/**
*
* @studentName EmmanuelKianda
* @studentNumber 10081944
* @PROG6212
* @Part 2
*/
{
    /// <summary>
    /// Interaction logic for CaptureStudy.xaml
    /// </summary>
    public partial class CaptureStudy : Window
    {
        // Creating Global Variables
        static double csHoursStudied;
        static string csModuleCode;
        static string csDateStudied;

        // Creating Getters and Setters
        public static double CsHoursStudied { get => csHoursStudied; set => csHoursStudied = value; }
        public static string CsModuleCode { get => csModuleCode; set => csModuleCode = value; }
        public static string CsDateStudied { get => csDateStudied; set => csDateStudied = value; }

        public CaptureStudy()
        {
            InitializeComponent();

            

            foreach (Entry item in u3.Store.storeModule.entryDetails) // Foreach loop to look through variables inside entryDetails
            {
                ModuleList.Items.Add(item.moduleCode); // The module codes from the entryDetails list are used to populate the items of the combo box.


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

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // Creating Local Variable
            bool correctInput = false;

            // Creating While loop to prompt the user until they enter valid input
            while (correctInput == false)
            {
                try
                {
                    // Storing user's input
                    CsHoursStudied = double.Parse(txtHoursStudied.Text);
                    CsDateStudied = txtSemesterStartDt.Text;
                    CsModuleCode = ModuleList.SelectedItem.ToString();


                    this.Hide(); // Closing current window
                    u6.Summary.Summary winSum = new u6.Summary.Summary(); // Creating object for {Summary}
                    winSum.Show();// Opening {Summary}
                    correctInput = true; // Setting the correctInput as true to allow the user to exit the While Loop.

                }

                catch (FormatException) // Error Handling
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    MessageBoxResult alert = MessageBox.Show(this, "Please Enter a Numeric value", "Invalid Input", // Notifying user
                        MessageBoxButton.OK, MessageBoxImage.Error);

                    if (alert == MessageBoxResult.OK)
                    {
                        this.Hide(); // Closing current window
                    }
                    correctInput = true;  // Setting the correctInput as true to allow the user to exit the While Loop.
                    CaptureStudy CaptureWin = new CaptureStudy(); // Creating object to reference {CaptureStudy}
                    CaptureWin.Show(); // Opening {CaptureStudy}


                }


            }


        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Closing current window
            u1.HomePage.HomePage HomeWin = new u1.HomePage.HomePage(); // Creating object for {HomePage}
            HomeWin.Show();// Opening {HomePage}
        }
    }
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/
