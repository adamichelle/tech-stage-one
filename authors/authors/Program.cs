using System;

namespace authors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------- Function 1: Active Authors --------");
            var activeAuthors = AuthorsLib.GetUsernames(10);
            var authorWithHighestCommentCount = AuthorsLib.GetUsernameWithHighestCommentCount();
            if(activeAuthors != null && activeAuthors.Count > 0)
            {
                foreach (var activeAuthor in activeAuthors)
                {
                    Console.WriteLine(activeAuthor);
                }
            }
            else
            {
                Console.WriteLine("No list of active authors");
            }


            Console.WriteLine("\n-------- Function 2: Author with highest comment count --------");
            Console.WriteLine(authorWithHighestCommentCount);


            Console.WriteLine("\n-------- Function 2: Authors by record date from oldest to newest --------");
            var authorsByRecordDate = AuthorsLib.GetUsernamesSortedByRecordDate(15);
            if(authorsByRecordDate != null && authorsByRecordDate.Count > 0)
            {
                foreach (var author in authorsByRecordDate)
                {
                    Console.WriteLine(author);
                }
            }
            else
            {
                Console.WriteLine("No list of authors");
            }
        }

        
    }
}
