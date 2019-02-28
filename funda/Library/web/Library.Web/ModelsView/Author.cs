namespace Library.Web
{
    public class Author
    {
        /// <summary>
        /// 
        /// </summary>
        public string ISBN
        {
            get;
            private set;
        }
        /// <summary>
        /// Author first name
        /// </summary>
        public string firstName
        {
            get;
            private set;
        }

        /// <summary>
        /// Author last name
        /// </summary>
        public string lastName
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor of author class
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Author(string ISBN, string firstName, string lastName)
        {
            this.ISBN = ISBN;this.firstName = firstName;this.lastName = lastName;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return lastName + ", " + firstName;
        }
    }
}
