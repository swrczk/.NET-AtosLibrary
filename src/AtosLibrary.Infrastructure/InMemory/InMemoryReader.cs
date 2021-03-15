using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Infrastructure.InMemory
{
    public class InMemoryReader : IInMemoryDb<ReaderEntity>
    {
        private readonly List<ReaderEntity> _readerEntities;

        public InMemoryReader()
        {
            _readerEntities = ReaderData();
        }

        public ReaderEntity Get(Guid id)
        {
            return _readerEntities.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ReaderEntity> GetAll()
        {
            return _readerEntities;
        }

        public void Add(ReaderEntity entity)
        {
            _readerEntities.Add(entity);
        }

        public void Edit(ReaderEntity readerEntity)
        {
            var reader = Get(readerEntity.Id);
            reader.Name = readerEntity.Name;
            reader.Surname = readerEntity.Surname;
            reader.City = readerEntity.City;
            reader.Country = readerEntity.Country;
        }

        public void Delete(Guid id)
        {
            var reader = Get(id);
            _readerEntities.Remove(reader);
        }

        private List<ReaderEntity> ReaderData()
        {
            var readerEntities = new List<ReaderEntity>();

            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Rafał", "Chalimoniuk", "Polska", "Jawor"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Peter", "Wandycz", "Polska", "Nysa"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Wladek", "Siwak", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Krzysztof", "Klekot", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Kajtek", "Światły", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Aleksandra", "Ziobrowska", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Kacper", "Kania", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Sylwia", "Majchrowska", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Wiktoria", "Zimnowoda", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Jędrzej", "Ratajczak", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Joanna", "Komorniczak", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Kasia", "Bucka", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Aleksandra", "Świerczek", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Mateusz", "Sarnowski", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Wojciech", "Magnus", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Roksana", "Kołacz", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Justyna", "Zienkiewicz", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Michał", "Sokołowski", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Basia", "Kemska", "Polska", "Wrocław"));
            readerEntities.Add(new ReaderEntity(Guid.NewGuid(), "Ewa", "Dudycz", "Polska", "Wrocław"));

            return readerEntities;
        }
    }
}