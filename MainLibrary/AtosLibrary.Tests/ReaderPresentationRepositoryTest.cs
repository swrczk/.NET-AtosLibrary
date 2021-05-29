using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtosLibrary.Domain.Book;
using AtosLibrary.Domain.Reader;
using AtosLibrary.Infrastructure.Entities;
using AtosLibrary.Presentation.Book;
using AtosLibrary.Presentation.Reader;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AtosLibrary.Tests
{
    [TestFixture]
    class ReaderPresentationRepositoryTest
    {
        private Guid _id;
        private List<ReaderEntity> ReaderData { get; set; }

        [Test]
        public async Task CheckGetBook()
        {
            var repositoryUnderTest = PrepareServiceForTests();
            repositoryUnderTest.Get(_id).Name.Should().Be(ReaderData[0].Name);
            repositoryUnderTest.Get(_id).Surname.Should().Be(ReaderData[0].Surname);
            repositoryUnderTest.Get(_id).Country.Should().Be(ReaderData[0].Country);
            repositoryUnderTest.Get(_id).City.Should().Be(ReaderData[0].City);
        }

        [Test]
        public async Task CheckGetList()
        {
            var repositoryUnderTest = PrepareServiceForTests();
            repositoryUnderTest.GetList().Count().Should().Be(ReaderData.Count);
        }
        [Test]
        public async Task CheckSearch()
        {
            var repositoryUnderTest = PrepareServiceForTests();
            repositoryUnderTest.Search("Surna").ToList()[0].Id.Should().Be(ReaderData[0].Id);
        }

        ReaderPresentationRepository PrepareServiceForTests()
        {
            PrepareData();
            var entityRepository = PreprareRepository();
            return new ReaderPresentationRepository(entityRepository);
        }

        void PrepareData()
        {
            _id = new Guid();
            ReaderData = new List<ReaderEntity>();
            var reader = new ReaderEntity(_id, "Name", "Surname", "Country", "City");
            ReaderData.Add(reader);
        }

        IReaderRepository PreprareRepository()
        {
            var mockedRepository = new Mock<IReaderRepository>();
            mockedRepository.Setup(f => f.Get(It.IsAny<Guid>()))
                .Returns(ReaderData[0]);
            mockedRepository.Setup(f => f.GetList())
                .Returns(ReaderData);
            return mockedRepository.Object;
        }
    }
}
