using System;

namespace AtosLibrary.Application.Features.DeleteBook
{
    public class DeleteBookCommand 
    {
        public DeleteBookCommand(Guid bookModelId)
        {
            Id = bookModelId;
        }
        public Guid Id { get; set; }
    }
}