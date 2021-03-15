using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtosLibrary.Infrastructure.Entities;
using AtosLibrary.Infrastructure.SQLDataBase;

namespace AtosLibrary.Domain.Reader
{
    public class ReaderRepositoryDB : IReaderRepository
    {
        private AtosLibraryContext _context;

        public ReaderRepositoryDB(AtosLibraryContext context)
        {
            _context = context;
        }
        public void Save(ReaderEntity readerEntity)
        {
            this._context.Reader.Add(readerEntity);
            this._context.SaveChanges();
        }

        public void Edit(ReaderEntity readerEntity)
        {
            var readerToEdit = Get(readerEntity.Id);

            readerToEdit.Id = readerEntity.Id;
            readerToEdit.Name = readerEntity.Name;
            readerToEdit.Surname = readerEntity.Surname;
            readerToEdit.Country = readerEntity.Country;
            readerToEdit.City = readerEntity.City;

            this._context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            this._context.Reader.Remove(Get(id));
            this._context.SaveChanges();
        }

        public ReaderEntity Get(Guid id)
        {
            return this._context.Reader.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ReaderEntity> GetList()
        {
            return this._context.Reader.ToList();
        }

        private void AddReaderData()
        {
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Rafał", "Chalimoniuk", "Polska", "Jawor"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Peter", "Wandycz", "Polska", "Nysa"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Wladek", "Siwak", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Krzysztof", "Klekot", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Kajtek", "Światły", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Aleksandra", "Ziobrowska", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Kacper", "Kania", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Sylwia", "Majchrowska", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Wiktoria", "Zimnowoda", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Jędrzej", "Ratajczak", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Joanna", "Komorniczak", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Kasia", "Bucka", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Aleksandra", "Świerczek", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Mateusz", "Sarnowski", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Wojciech", "Magnus", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Roksana", "Kołacz", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Justyna", "Zienkiewicz", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Michał", "Sokołowski", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Basia", "Kemska", "Polska", "Wrocław"));
            this._context.Reader.Add(new ReaderEntity(Guid.NewGuid(), "Ewa", "Dudycz", "Polska", "Wrocław"));

            this._context.SaveChanges();
        }
    }
}
