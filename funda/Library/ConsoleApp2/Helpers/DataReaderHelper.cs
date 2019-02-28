using CsvHelper;
using LibraryApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryApp.Helper
{
    class DataReaderHelper
    {
        /// <summary>
        /// 
        /// </summary>
        //public static string[] ReadHeader()
        //{
        //    using (StreamReader csv = new StreamReader("DataFiles/Books.csv"))
        //    {
        //        string headerLine = csv.ReadLine();
        //        return headerLine.Split(',');
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<BookModelView> CsvBookReader()
        {
            using (CsvReader booksCSV = new CsvReader(new StreamReader("DataFiles/Books.csv"), true))
            {
                return (booksCSV.GetRecords<Helper.BookModelView>().ToList<BookModelView>());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Author> CsvAuthorReader()
        {
            using (CsvReader authorsCSV = new CsvReader(new StreamReader("DataFiles/Authors.csv"), true))
            {
                return (authorsCSV.GetRecords<Author>().ToList<Author>());
                
            }
        }

        public static List<Book> JsonBookReader()
        {

            using (StreamReader r = new StreamReader("DataFiles/Books.json"))
            {
                string json = r.ReadToEnd();
                return (JsonConvert.DeserializeObject<List<Book>>(json));                
            }
        }
    }
}
