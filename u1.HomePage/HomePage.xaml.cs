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
using System.Windows.Threading;

namespace PiTimeSolution.u1.HomePage
/**
*
* @studentName EmmanuelKianda
* @studentNumber 10081944
* @PROG6212
* @Part 2
*/
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {

        // Declaring global variables
        static int emptyEntry = 0;

        // Creating Getters and Setters
        public static int EmptyEntry { get => emptyEntry; set => emptyEntry = value; }

        // Declaring variables
        DispatcherTimer timer;
        double panelWidth;
        double windowWidth;
        bool hidden;

        public HomePage()
        {

            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 0);
            timer.Tick += Timer_Tick; ;

            panelWidth = sidePanel.Width;
            windowWidth = windowContent.Width;

                welcomeMsg.Visibility = Visibility.Visible; // Making message visible
                welcomeMsg.Text = "Signed in as, " + DbController.StUsername; // Displaying welcome message to user
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Controlling side panel
          if (hidden)
            {
                sidePanel.Width += 1;
                windowContent.Width -= 1;


                if (sidePanel.Width >= panelWidth && windowContent.Width >= windowWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }

          else
            {
                sidePanel.Width -= 1;
                windowContent.Width += 1;



                if (sidePanel.Width <= 50)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start(); // Starting timer
        }

        private void panelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // Code to control the direction of the mouse
            {
                DragMove();
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


        private void storeBtn_Click(object sender, RoutedEventArgs e)
        {
                EmptyEntry = 1; // Entry value set to 1

                this.Hide(); // Closing current window
                u2.Semester.ModuleSelection selectWin = new u2.Semester.ModuleSelection(); // Creating object for {ModuleSelection}
            selectWin.Show();// Opening {ModuleSelection}


        }

        private void captureBtn_Click(object sender, RoutedEventArgs e)
        {

                if (EmptyEntry == 0) // Checking if Entry number value is 0
                {
                    MessageBoxResult alert = MessageBox.Show(this, "You have not Stored a Module yet", "Error", //Notifying user
                        MessageBoxButton.OK, MessageBoxImage.Error);

                    if (alert == MessageBoxResult.OK) // Checking if user selected "OK"
                    {
                        this.Hide();
                    }
                    this.Hide(); // Closing current window
                    HomePage HomeWin = new HomePage(); // Creating object for {HomePage}
                    HomeWin.Show();// Opening {HomePage}
                }
                else // Else if the Entry number is greater than 0
                {
                    this.Hide(); // Closing current window
                    u5.Capture.CaptureStudy captureWin = new u5.Capture.CaptureStudy(); // Creating object for {CaptureStudy}
                captureWin.Show();// Opening {CaptureStudy}

                }

       

        }


        private void viewDatabtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Closing current window
            u7.ViewData.viewDataUI viewData = new u7.ViewData.viewDataUI(); // Creating object for {viewDataUI}
            viewData.Show();// Opening {viewDataUI}
        }

        private void logOutBtn_Click(object sender, RoutedEventArgs e)
        {
            // Clearing 
            EmptyEntry = 0;
            u3.Store.storeModule.entryDetails.Clear();
            u4.Analytics.ModuleAnalytics.studyDetails.Clear();

            this.Hide(); // Closing current window
            StartUP.authoriseUser startUp = new StartUP.authoriseUser(); // Initiating {authoriseUser}
            startUp.Show();// Opening {authoriseUser}
        }

    }
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/

