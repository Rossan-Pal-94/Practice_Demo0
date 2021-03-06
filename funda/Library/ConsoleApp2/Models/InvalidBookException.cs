﻿using System;

namespace LibraryApp.Models
{
    /// <summary>
    /// Customised Exception Class, It will throw an exception when any field of book is incorrect
    /// </summary>
    public class InvalidBookException : Exception
    {
        /// <summary>
        /// Passing message to the base class constructor so that message is available to the CLR.
        /// </summary>
        /// <param name="name"></param>
        public InvalidBookException(string name)
        : base(name)
        {

        }

    }
}
