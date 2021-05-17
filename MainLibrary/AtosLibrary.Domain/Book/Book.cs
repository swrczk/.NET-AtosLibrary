using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AtosLibrary.Infrastructure;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Domain.Book
{
    public class Book
    {
        private readonly Guid _id;
        private readonly string _name;
        private readonly string _description;
        private readonly int _number;
        private readonly List<Guid> _readers;

        internal Book(Guid bookId, IBookRepository bookRepository)
        {
            _id = bookId;
            var result = bookRepository.Get(bookId);
            _name = result.Name;
            _description = result.Description;
            _number = result.Number;
            _readers = result.Readers ?? new List<Guid>();
        }

        internal Book(string name, string description, int number)
        {
            _id = Guid.NewGuid();
            _name = name;
            _description = description;
            _number = number;
            _readers = new List<Guid>();
        }

        public Book(Guid bookId, string name, string description,  int number)
        {
            _id = bookId;
            _name = name;
            _description = description;
            _number = number;
            _readers = new List<Guid>();
        }

        public Guid GetId()
        {
            return this._id;
        }

        public void Register(IBookRepository bookRepository)
        {
            bookRepository.Save(new BookEntity(_id, _name, _description, _number));
        }

        public void Reserve(Guid readerId, IBookRepository bookRepository)
        {
            if (_readers.Contains(readerId))
            {
                throw new Exception("Is reserved by you. <3");
            }

            if (_number == _readers.Count)
            {
                throw new Exception("All copies are reserved or rented. Please try later.");
            }

            _readers.Add(readerId);


            //WYWOLUJE SIE 2 RAZY
            /*
            bookRepository.UpdateReservation(_id, _readers);
            */
        }

        public void Edit(IBookRepository bookRepository)
        {
            bookRepository.Edit(new BookEntity(_id, _name, _description, _number, _readers)); //_commandName, _commandDescription, _commandNumber, _commandReaders));
        }

        public static  void Delete(IBookRepository bookRepository, Guid id)
        {
            bookRepository.Delete(id);
        }
    }
}