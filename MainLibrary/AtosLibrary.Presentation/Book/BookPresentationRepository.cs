using System;
using System.Collections.Generic;
using AtosLibrary.Domain.Book;

namespace AtosLibrary.Presentation.Book
{
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class BookPresentationRepository : IBookPresentationRepository
    {
        private readonly IBookRepository _bookRepository;

        public BookPresentationRepository(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookModel Get(Guid id)
        {
            var entity = _bookRepository.Get(id);

            BookModel bookModel = new BookModel();

            bookModel.Id = entity.Id;
            bookModel.Number = entity.Number;
            bookModel.Name = entity.Name;
            bookModel.Description = entity.Description;

            return bookModel;
        }

        public IEnumerable<BookModel> GetList()
        {
            var entities = _bookRepository.GetList();

            var books = new List<BookModel>();

            foreach (var entity in entities)
            {
                var bookModel = new BookModel();

                bookModel.Id = entity.Id;
                bookModel.Number = entity.Number;
                bookModel.Name = entity.Name;
                bookModel.Description = entity.Description;

                books.Add(bookModel);
            }

            return books;
        }
        public IEnumerable<BookModel> Search(string searchText)
        {
            var entities = _bookRepository.GetList();

            var books = new List<BookModel>();
            
            var keyWords = searchText?.Split(" ");

            foreach (var entity in entities)
            {
                if (isTrue(keyWords) || keyWords.Any(x=> entity.Name.ToLower().Contains(x.ToLower()) || entity.Description.ToLower().Contains(x.ToLower()) || entity.Number.ToString().ToLower().Contains(x.ToLower())))
                {
                    var book = new BookModel
                                     {
                                         Id = entity.Id, 
                                         Description = entity.Description, 
                                         Name = entity.Name
                                     };

                    books.Add(book);
                }
            }

            return books;
        }


        //Więcej niż 2 warunki rozpisywać do metod
        private static bool isTrue(string[] keyWords)
        {
            return true  && keyWords == null;
        }
    }
}