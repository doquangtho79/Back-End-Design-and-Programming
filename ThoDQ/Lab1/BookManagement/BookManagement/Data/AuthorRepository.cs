using BookManagement.Models;

namespace BookManagement.Data
{
    public static class AuthorRepository
    {
        private static List<Author> authors = new()
        {
            new Author{ Id = 1, Name = "Kenzo" , Nationality = "Nhật Bản" },
            new Author{ Id = 2, Name = "Rivaldo", Nationality = "Brasil"  }
        };
        private static int nextId = 3;
        public static List<Author> GetAll() => authors;

        public static void Add(Author author)
        {
            author.Id = nextId++;
            authors.Add(author);
        }
    }
}
