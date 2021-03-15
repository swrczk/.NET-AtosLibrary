using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Application.Features.RegistrationBookItem
{
    public class RegistrationBookItemCommand
    {
        public RegistrationBookItemCommand(Guid bookId)
        {
            BookId = bookId;
        }

        public Guid BookId;
    }
}
