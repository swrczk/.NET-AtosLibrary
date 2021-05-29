using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtosLibrary.Domain.Book;
using AtosLibrary.Infrastructure.Entities;
using AtosLibrary.Presentation.Book;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using NUnit.Framework;
using FluentAssertions;

namespace AtosLibrary.Tests
{
    [TestFixture]
    class BookPresentationRepositoryTest
    {
        private Guid _id;
        private List<BookEntity> BookData { get; set; }

        [Test]
        public async Task CheckGetBook()
        {
            var repositoryUnderTest = PrepareServiceForTests();
            repositoryUnderTest.Get(_id).Name.Should().Be(BookData[0].Name);
            repositoryUnderTest.Get(_id).Description.Should().Be(BookData[0].Description);
            repositoryUnderTest.Get(_id).Number.Should().Be(BookData[0].Number);
        }

        [Test]
        public async Task CheckGetList()
        {
            var repositoryUnderTest = PrepareServiceForTests();
            repositoryUnderTest.GetList().Count().Should().Be(BookData.Count);
        }
        [Test]
        public async Task CheckSearch()
        {
            var repositoryUnderTest = PrepareServiceForTests();
            repositoryUnderTest.Search("Descri").ToList()[0].Id.Should().Be(BookData[0].Id);
        }

        BookPresentationRepository PrepareServiceForTests()
        {
            PrepareData();
            var entityRepository = PreprareRepository();
            return new BookPresentationRepository(entityRepository);
        }

        void PrepareData()
        {
            _id = new Guid();
            BookData = new List<BookEntity>();
            var book = new BookEntity(_id, "Book", "Description", 1, new List<Guid>());
            BookData.Add(book);
        }

        IBookRepository PreprareRepository()
        {
            var mockedRepository = new Mock<IBookRepository>();
            mockedRepository.Setup(f => f.Get(It.IsAny<Guid>()))
                .Returns(BookData[0]);
            mockedRepository.Setup(f => f.GetList())
                .Returns(BookData);
            return mockedRepository.Object;
        }
    }
}
