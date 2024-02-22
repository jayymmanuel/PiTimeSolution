/* ----------------------------------------------------------- Start of the code -----------------------------------------------------------*/
using CalculateLibrary;
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
    /// Interaction logic for SavedWindow.xaml
    /// </summary>
    public partial class SavedWindow : Window
    {
       
        public SavedWindow()
        {
            InitializeComponent();

            // Ressetting dependant variables from the storeModule UI to their original state
            storeModule.ModuleLimit = 0;
            storeModule.SavedData = 0;

            StartTimer(); // Calling method
        }

        DispatcherTimer timer = null; // Setting initial value to null
        private void StartTimer()
        {
            timer = new DispatcherTimer(); // Creating new object 
            timer.Interval = TimeSpan.FromSeconds(1); // Setting timer to 1 Second
            timer.Tick += new EventHandler(timer_Elapsed); // Calling method
            timer.Start(); // Starting timer


        }

        private void timer_Elapsed(object sender, EventArgs e)
        {
            timer.Stop(); // Stopping timer

            this.Hide(); // Closing current windown
            u4.Analytics.ModuleAnalytics analyticsWin = new u4.Analytics.ModuleAnalytics(); // Creating object to reference {ModuleAnalytics}
            analyticsWin.Show(); // Opening {ModuleAnalytics}
        }
    }
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/

