using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.BookItem;

namespace AtosLibrary.Application.Features.DeleteBookItem
{
    public class DeleteBookItemCommandHandler : ICommandHandler<DeleteBookItemCommand>
    {
        private IBookItemFactory _bookItemFactory;
        private IBookItemRepository _bookItemRepository;

        public DeleteBookItemCommandHandler(IBookItemFactory bookItemFactory, IBookItemRepository bookItemRepository)
        {
            _bookItemFactory = bookItemFactory;
            _bookItemRepository = bookItemRepository;
        }

        public void Handle(DeleteBookItemCommand command)
        {
            _bookItemRepository.Delete(command.Id);
        }
    }
}
