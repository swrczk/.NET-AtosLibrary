using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Presentation.BookItem
{
    public class BookItemModel
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string Description { get; set; }
        public EnumBookItemStatus BookItemStatus { get; set; }
    }
}
