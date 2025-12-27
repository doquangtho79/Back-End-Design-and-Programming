using BookManagement.Models;

namespace BookManagement.Data
{
    public static class BookRepository
    {
        private static List<Book> books = new()
        {
            new Book{ Id = 1, Title = "Doremon", Author = "Kenzo" },
            new Book{ Id = 2, Title = "Cuốn theo chiều gió", Author = "Rivado"}
        };
        
        private static int nextId = 3;

        public static List<Book> GetAll() => books;

        public static Book? GetById(int id) => books.FirstOrDefault(b => b.Id == id);

        public static void Add(Book book)
        {
            book.Id = nextId++;
            books.Add(book);
        }

        public static bool Update(Book book)
        {
            var index = books.FindIndex(b => b.Id == book.Id);
            if (index == -1) return false;
            books[index] = book;
            return true;
        }
    }
}
