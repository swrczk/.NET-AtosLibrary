using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Domain.BookItem;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Application.Features.DeleteBookItem
{
    public class DeleteBookItemCommand
    {
        public DeleteBookItemCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id;
    }
}
