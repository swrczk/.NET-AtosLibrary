using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.BookItem;

namespace AtosLibrary.Application.Features.RegistrationBookItem
{
    public class RegistrationBookItemCommandHandler : ICommandHandler<RegistrationBookItemCommand>
    {

        private readonly IBookItemFactory _bookItemFactory;
        private readonly IBookItemRepository _bookItemRepository;

        public RegistrationBookItemCommandHandler(IBookItemRepository bookItemRepository, IBookItemFactory bookItemFactory)
        {
            _bookItemRepository = bookItemRepository;
            _bookItemFactory = bookItemFactory;
        }

        public void Handle(RegistrationBookItemCommand command)
        {
            var bookItem = _bookItemFactory.Create(command.BookId);
            _bookItemRepository.Save(bookItem.MakeEntity());
        }
    }
}
