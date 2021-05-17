using System;

namespace AtosLibrary.Application.Features.UpdateBook
{
    public class EditBookCommand
    {
        public EditBookCommand(Guid bookModelId, string bookModelName, string bookModelDescription,  int bookModelNumber)
        {
            Id = bookModelId;
            BookModelName = bookModelName;
            BookModelDescription = bookModelDescription;
            BookModelNumber = bookModelNumber;
        }

        public string BookModelName { get; set; }

        public string BookModelDescription { get; set; }

        public int BookModelNumber { get; set; }

        public Guid Id { get; set; }
    }
}
