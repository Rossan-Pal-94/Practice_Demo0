using LibraryApp.Helper;
using System;

namespace LibraryApp
{
    /// <summary>
    /// Main class to start library application
    /// </summary>
    class Program
    {
        /// <summary>
        /// Method to log the uotput on console (screen).
        /// </summary>
        /// <param name="msg"></param>
        public static void DisplayMsg(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Main method excetion starts here
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            LibraryHelper.LibraryExecutionStart();
        }
    }
}
