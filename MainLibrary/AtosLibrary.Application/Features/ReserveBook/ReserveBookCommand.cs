using System;

namespace AtosLibrary.Application.Features.ReserveBook
{
    public class ReserveBookCommand
    {
        public ReserveBookCommand(Guid bookModelId, Guid readerModelId)
        {
            BookId = bookModelId;
            ReaderId = readerModelId;
        }
        public Guid BookId { get; set; }
        public Guid ReaderId { get; set; }
    }
}