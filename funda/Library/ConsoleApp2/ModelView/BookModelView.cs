namespace LibraryApp.Helper
{
    class BookModelView
    {
        public string ISBN
        {
            get;
            private set;
        }
        /// <summary>
        /// Book title
        /// </summary>
        public string title
        {
            get;
            private set;
        }

        public string language
        {
            get;
            private set;
        }

        public int? pages
        {
            get;
            private set;
        }

        /// <summary>
        /// Publishing year of book
        /// </summary>
        public int? yearOfPublishing
        {
            get;
            private set;
        }

        public BookModelView(string ISBN, string title, string language, int? pages, int? yearOfPublishing)
        {
            this.ISBN = ISBN;this.title = title;this.language = language;this.pages = pages.GetValueOrDefault();this.yearOfPublishing = yearOfPublishing.GetValueOrDefault();
        }
    }
}
