using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.BookItem;

namespace AtosLibrary.Application.Features.EditBookItem
{
    public class EditBookItemCommandHandler : ICommandHandler<EditBookItemCommand>
    {
        private readonly IBookItemFactory _bookItemFactory;
        private readonly IBookItemRepository _bookItemRepository;
        public EditBookItemCommandHandler(IBookItemFactory bookItemFactory, IBookItemRepository bookItemRepository)
        {
            _bookItemFactory = bookItemFactory;
            _bookItemRepository = bookItemRepository;
        }
        public void Handle(EditBookItemCommand command)
        {
            var bookItem =
                _bookItemFactory.CloneBookItem(command.Id, command.BookId, command.Description, command.Status);
            _bookItemRepository.Edit(bookItem.MakeEntity());
        }
    }
}
