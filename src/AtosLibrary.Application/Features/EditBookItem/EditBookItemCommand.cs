using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Application.Features.EditBookItem
{
    public class EditBookItemCommand
    {
        public EditBookItemCommand(Guid id, Guid bookId, string description, EnumBookItemStatus status)
        {
            Id = id;
            BookId = bookId;
            Description = description;
            Status = status;
        }

        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string Description { get; set; }
        public EnumBookItemStatus Status { get; set; }


    }
}
