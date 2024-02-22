/* ----------------------------------------------------------- Start of the code -----------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Windows;

namespace PiTimeSolution
{
/**
*
* @studentName EmmanuelKianda
* @studentNumber 10081944
* @PROG6212
* @Part 2
*/

    public class DbController
    {
        // Creating global variables
        private static int stNumber;
        private static string stUsername;

        DataTable dt = new DataTable();


        SqlConnection sqlConnection;


        // Creating getters and setters
        public static int StNumber { get => stNumber; set => stNumber = value; }
        public DataTable Dt { get => dt; set => dt = value; }
        public static string StUsername { get => stUsername; set => stUsername = value; }

        public DbController()
        {
            // Initiating dynamic connection String/Path to application Database
            string CurrentDirectory = Environment.CurrentDirectory;
            string modDirectory = CurrentDirectory.Replace(@"bin\Debug", "studentInfo.mdf");
            string connection_string = @"Data source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + modDirectory + @"; Integrated Security = True";
             sqlConnection = new SqlConnection(connection_string);
        }

        public  void TransferToDB(Student student)
        {
            SqlCommand cmd = new SqlCommand(); // Creating an object for command 


            cmd.CommandType = System.Data.CommandType.Text;

            // SQL statement to insert values into the table

            cmd.CommandText = "INSERT INTO studentDetails(username, password) VALUES ('" + student.StUsername +  "'," + "'" + convertByte(hashedOut(student.StPassword))  + "')";


            cmd.Connection = sqlConnection;

            sqlConnection.Open(); // Opening connection

            cmd.ExecuteNonQuery();

            sqlConnection.Close(); // Closing connection

            //--------------------------------- STARTING SECOND SQL QUERY ----------------------------------
            sqlConnection.Open(); // Opening connection
            SqlCommand cmd2 = new SqlCommand("SELECT studentId, username FROM studentDetails WHERE username = @username", sqlConnection);
            cmd2.Parameters.AddWithValue("username", student.StUsername);




            SqlDataReader reader; // Declaring SqlDataReader
            reader = cmd2.ExecuteReader();

            reader.Read();
            stNumber = (int)reader[0]; // Storing first position of query into variable

            stUsername = (string)reader[1]; // Storing second position of query into variable


            sqlConnection.Close(); // Closing connection
            //-----------------------------------------------------------------------------------------------------------



        }


        public bool accessCredentials()
        {
            bool isVerified = true; // Declaring boolean variable


            sqlConnection.Open(); // Opening connection

            // Initianing SELECT statement
            SqlCommand cmd =  new SqlCommand("SELECT studentId, username FROM studentDetails WHERE username = @username AND password = @password", sqlConnection);
            // Storing variables inside query
            cmd.Parameters.AddWithValue("username", StartUP.loginUI.CUsername);
            cmd.Parameters.AddWithValue("password", convertByte(hashedOut(StartUP.loginUI.CPassword)));

            SqlDataReader reader; // Declaring SqlDataReader
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                stNumber = (int)reader[0]; // Storing first position of query into variable

                stUsername = (string)reader[1]; // Storing second position of query into variable



                isVerified = true; // Setting boolean variable to true
                MessageBox.Show("Welcome, " + stUsername + "\n" + "Student ID:" +stNumber, "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                isVerified = false; // Setting boolean variable to false
            }

            sqlConnection.Close(); // Closing connection

            return isVerified; // returning value of boolean

        }

        public bool uniqueUser(Student student)
        {
            bool isUnique = true; // Declaring boolean variable


            sqlConnection.Open(); // Opening connection

            // Initianing SELECT statement
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentDetails WHERE username = @username", sqlConnection);
            
            // Storing variables inside query
            cmd.Parameters.AddWithValue("username", student.StUsername);




            if ((int)cmd.ExecuteScalar() > 0) // If statement to determine whether the sql query returns a row
            {

                isUnique = false; // Setting boolean variable to false
            }
            else
            {
                isUnique = true; // Setting boolean variable to true
            }

            sqlConnection.Close(); // Close connection

            return isUnique; // returning value of boolean
        }




        public void storeModuleDetails()
        {
            SqlCommand cmd = new SqlCommand(); // Creating an object for command 

            cmd.CommandType = CommandType.Text;
            // SQL statement to insert values into the table

            // -- Declaring Insert command
            cmd.CommandText = "INSERT INTO moduleDetails(moduleName, moduleCode, moduleCredits, ClassHoursperWeek, semStartDate, studentId) " +
                "VALUES ('" + u4.Analytics.ModuleAnalytics.TempModName + "'," + "'"+ u4.Analytics.ModuleAnalytics.TempModCode + "'," + "'" + u4.Analytics.ModuleAnalytics.TempModCredits + "'," + "'" + u4.Analytics.ModuleAnalytics.TempModHours + "'," + "'" + u2.Semester.ModuleSelection.StSemStartDt + "'," + "'" + stNumber + "')";

            cmd.Connection = sqlConnection;

            sqlConnection.Open(); // Opening connection

            cmd.ExecuteNonQuery();

            sqlConnection.Close(); // Closing connection
        }


        public void storeModuleProgress()
        {

            SqlCommand cmd = new SqlCommand(); // Creating an object for command 

            cmd.CommandType = System.Data.CommandType.Text;
            // SQL statement to insert values into the table

            cmd.CommandText = "INSERT INTO moduleProgress(moduleCode, selfStudyRequired, hoursStudied, remaingHours, studyDate, studentId) " +
                "VALUES ('" + u5.Capture.CaptureStudy.CsModuleCode + "'," + "'" + String.Format("{0:0.00}", u6.Summary.Summary.CurrentSelection) + "'," + "'" + u6.Summary.Summary.HoursStudied + "'," + "'" + u6.Summary.Summary.RemainingHours + "'," + "'" + u5.Capture.CaptureStudy.CsDateStudied + "'," + "'" + stNumber + "')";


            cmd.Connection = sqlConnection;

            sqlConnection.Open(); // Opening connection

            cmd.ExecuteNonQuery();

            sqlConnection.Close(); // Closing connection
        }


        public void retreiveUserDetails()
        {

            // SQL statement to select values from multiple tables to return a summary of the information to the User
            SqlCommand cmd = new SqlCommand("SELECT  sd.studentId AS 'Student ID', md.moduleName AS 'Module Name', md.moduleCode AS 'Module Code', md.ClassHoursperWeek AS 'Class Hours per Week', md.moduleCredits AS 'Module Credits', mp.selfStudyRequired AS 'Required self-study hours ID', mp.hoursStudied AS 'Hours studied', mp.remaingHours AS 'Remaining Hours', mp.studyDate AS 'Last Update' FROM studentDetails sd, moduleProgress mp, moduleDetails md WHERE sd.studentId = @studentNumber AND mp.studentId = @studentNumber AND md.studentId = @studentNumber AND md.moduleCode = mp.moduleCode", sqlConnection);
            cmd.Parameters.AddWithValue("studentNumber", stNumber);

            

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            
            da.Fill(dt); // Populating data table with SqlDataAdapter which executes command statement 



        }

        public bool uniqueModule()
        {
            bool isUnique = true; // Declaring boolean variable


            sqlConnection.Open(); // Opening connection

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM moduleProgress WHERE moduleCode = @moduleCode AND studentId = @ID", sqlConnection);
            cmd.Parameters.AddWithValue("moduleCode", u5.Capture.CaptureStudy.CsModuleCode);
            cmd.Parameters.AddWithValue("ID", stNumber);





            if ((int)cmd.ExecuteScalar() > 0) // If statement to determine whether the sql query returns a row
            {

                isUnique = false; // Setting boolean variable to false
            }
            else
            {
                isUnique = true; // Setting boolean variable to true
            }

            sqlConnection.Close(); // Closing connection

            return isUnique; // Returning boolean variable
        }




        public static byte[] hashedOut(string CPassword)
        {
            byte[] tempSource;
            byte[] tempHash;

            // Create a byte array from source data
            tempSource = ASCIIEncoding.ASCII.GetBytes(CPassword);

            // Compute Hash based on source data
            tempHash = new MD5CryptoServiceProvider().ComputeHash(tempSource);

            return tempHash;
        }

        // Converting the Byte array to a string
        public static string convertByte(byte[] arrInput)
        {
            int i;
            StringBuilder sourceOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sourceOutput.Append(arrInput[i].ToString("X2"));
            }

            return sourceOutput.ToString();
        }


    }
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/
