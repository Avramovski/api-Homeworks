using Homework_02.Models;

namespace Homework_02
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {

            new Book()
            {
                Title = "AndrejBook",
                Author = "Andrej"
            },
            new Book()
            {
                Title = "MarioBook",
                Author = "Mario"
            }

        };
    }
}
    

