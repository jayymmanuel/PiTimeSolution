/* ----------------------------------------------------------- Start of the code -----------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiTimeSolution
{
/**
*
* @studentName EmmanuelKianda
* @studentNumber 10081944
* @PROG6212
* @Part 2
*/
    public class Student
    {

    private string stUsername;
    private string stPassword;

    public Student(string username, string password)
    {
        this.stUsername = username;
        this.stPassword = password;
    }

    // Creating Getters and Setters
    public string StUsername { get => stUsername; set => stUsername = value; }
    public string StPassword { get => stPassword; set => stPassword = value; }

}
}
/* -------------------------------------------------------------------------- End of the code --------------------------------------------------------------------------*/
