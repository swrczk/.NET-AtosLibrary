using System;

namespace AtosLibrary.Application.Features.DeleteReader
{
    public class DeleteReaderCommand 
    {
        public DeleteReaderCommand(Guid readerModelId)
        {
            Id = readerModelId;
        }
        public Guid Id { get; set; }
    }
}