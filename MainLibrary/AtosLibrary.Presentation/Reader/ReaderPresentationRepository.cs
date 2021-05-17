using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Domain.Reader;

namespace AtosLibrary.Presentation.Reader
{
    public class ReaderPresentationRepository : IReaderPresentationRepository
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderPresentationRepository(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public ReaderModel Get(Guid id)
        {
            var entity = _readerRepository.Get(id);

            ReaderModel reader = new ReaderModel();

            reader.Id = entity.Id;
            reader.Surname = entity.Surname;
            reader.Name = entity.Name;
            reader.City = entity.City;
            reader.Country = entity.Country;

            return reader;
        }

        public IEnumerable<ReaderModel> GetList()
        {
            var entities = _readerRepository.GetList();

            var readers = new List<ReaderModel>();

            foreach (var entity in entities)
            {
                var reader = new ReaderModel();

                reader.Id = entity.Id;
                reader.Surname = entity.Surname;
                reader.Name = entity.Name;

                readers.Add(reader);
            }

            return readers;
        }

        public IEnumerable<ReaderModel> Search(string searchText)
        {
            var entities = _readerRepository.GetList();

            var readers = new List<ReaderModel>();
            
            var keyWords = searchText?.Split(" ");

            foreach (var entity in entities)
            {
                if (isTrue(keyWords) || keyWords.Any(x=> entity.Name.ToLower().Contains(x.ToLower()) || entity.Surname.ToLower().Contains(x.ToLower()) || entity.Country.ToLower().Contains(x.ToLower()) || entity.City.ToLower().Contains(x.ToLower())))
                {
                    var reader = new ReaderModel
                    {
                        Id = entity.Id, 
                        Surname = entity.Surname, 
                        Name = entity.Name
                    };

                    readers.Add(reader);
                }
            }

            return readers;
        }


        //Więcej niż 2 warunki rozpisywać do metod
        private static bool isTrue(string[] keyWords)
        {
            return true  && keyWords == null;
        }
    }
}