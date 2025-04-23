//Будет БД библиотека, где будут храниться книги и формуляры на книги, в которых отслеживается выдача и сдача книги.
//Сама книга описывается структурой, которая содержит следующие поля: ФИО автора, наименование книги, год выпуска и издательство.
//Должны организовать заполнение БД, вывод сведений о книгах, которые ни разу не выдавались и вывод сведений о книгах, которые не сданы.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public struct Book
    {
        public string Author;
        public string Title;
        public int Year;
        public string Publisher;
    }

    public struct Form
    {
        public Book Book;
        public string IssueDate;
        public string ReturnDate;
    }

    class Library
    {
        private List<Book> books = new List<Book>();
        private List<Form> issueRecords = new List<Form>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void IssueBook(Book book, string issueDate)
        {
            bool isIssued = issueRecords.Any(r => r.Book.Equals(book) && string.IsNullOrEmpty(r.ReturnDate));
            if (!books.Contains(book)) Console.WriteLine($"Книги \"{book.Title}\" нет в библиотеке!\n");
            else if (isIssued) Console.WriteLine($"Книга \"{book.Title}\" уже выдана!\n");
            else issueRecords.Add(new Form{Book = book, IssueDate = issueDate, ReturnDate = ""});
        }

        public void ReturnBook(Book book, string returnDate)
        {
            var record = issueRecords.LastOrDefault(r => r.Book.Equals(book) && string.IsNullOrEmpty(r.ReturnDate));

            if (record.Equals(default(Form))) Console.WriteLine($"Книга \"{book.Title}\" не была выдана или уже возвращена!\n");
            else
            {
                int index = issueRecords.IndexOf(record);
                record.ReturnDate = returnDate;
                issueRecords[index] = record;
            }
        }

        public void PrintNeverIssuedBooks()
        {
            Console.WriteLine("Книги, которые никогда не выдавались:");
            var neverIssued = books.Where(b => !issueRecords.Any(r => r.Book.Equals(b)));

            foreach (var book in neverIssued)
            {
                Console.WriteLine($"{book.Author} - \"{book.Title}\" ({book.Year})");
            }
        }

        public void PrintNotReturnedBooks()
        {
            Console.WriteLine("Книги, которые не возвращены:");
            var notReturned = issueRecords.Where(r => string.IsNullOrEmpty(r.ReturnDate));

            foreach (var record in notReturned)
            {
                Console.WriteLine($"\"{record.Book.Title}\" - выдана: {record.IssueDate}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Library library = new Library();

            Book warAndPeace = new Book
            {
                Author = "Лев Толстой",
                Title = "Война и мир",
                Year = 1869,
                Publisher = "Русский вестник"
            };
            Book crimeAndPunishment = new Book
            {
                Author = "Фёдор Достоевский",
                Title = "Преступление и наказание",
                Year = 1866,
                Publisher = "Русский вестник"
            };
            Book cherryOrchard = new Book
            {
                Author = "Антон Чехов",
                Title = "Вишнёвый сад",
                Year = 1904,
                Publisher = "Знание"
            };

            library.AddBook(warAndPeace);
            library.AddBook(crimeAndPunishment);
            library.AddBook(cherryOrchard);
            
            library.IssueBook(warAndPeace, "12.07.2023");
            library.IssueBook(crimeAndPunishment, "15.07.2023");

            library.ReturnBook(crimeAndPunishment, "20.07.2023");
            library.ReturnBook(cherryOrchard, "22.22.2222");

            library.IssueBook(crimeAndPunishment, "23.08.2024");

            library.PrintNeverIssuedBooks();
            Console.WriteLine();
            library.PrintNotReturnedBooks();
        }
    }
}
