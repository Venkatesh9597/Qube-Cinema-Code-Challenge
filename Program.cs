using System;
using System.IO;
using GroupDocs.Search;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using Index = GroupDocs.Search.Index;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            SearchFile();
        }
        public static void SearchFile()
        {
            var url = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var mainpath = url.Replace("\\bin\\Debug\\netcoreapp3.1\\ConsoleApp1.dll", "");
            mainpath = mainpath.Replace("\\", "/");
            string attachment = mainpath + "/Files/";
            string Search = Console.ReadLine();
            string indexes = mainpath + "/Files/Index/";
            Index index = new Index(indexes);
            index.Add(attachment);
            SearchResult Seachresult = index.Search(Search);
            if (Seachresult.DocumentCount > 0)
            {
                foreach (FoundDocument result in Seachresult)
                {
                    Console.WriteLine("Resource Path : " + result.DocumentInfo.FilePath);
                    Console.WriteLine("Occurance Count : " + result.OccurrenceCount);
                }
            }
            else
            {
                Console.WriteLine("No Data Found");
            }

        }

    }
}
