/* ----------------------------------------------------------- start of the code -----------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace PROG6212_PART2.u7.ViewData
{
/**
*
* @studentName EmmanuelKianda
* @studentNumber 10081944
* @PROG6212
* @Part 2
*/
    /// <summary>
    /// Interaction logic for viewDataUI.xaml
    /// </summary>
    public partial class viewDataUI : Window
    {
        DbController controller = new DbController();  // Creating Object to reference DbController

        public viewDataUI()
        {
            InitializeComponent();

            controller.retreiveUserDetails(); // Invoking the method responsible to retrieve module details

            userData.ItemsSource = controller.Dt.DefaultView; // Populating data grid 



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
            this.Hide(); // Closing current window
            u1.HomePage.HomePage HomeWin = new u1.HomePage.HomePage(); // Initiating {HomePage}
            HomeWin.Show();// Opening {HomePage}
        }

    }
}
/* -------------------------------------------------------------------------- end of the code --------------------------------------------------------------------------*/
