using System;

namespace AtosLibrary.Application.Features.ReserveBookNew
{
    public class ReserveBookNewCommand
    {
        public ReserveBookNewCommand(Guid bookItemModelId, Guid readerModelId)
        {
            BookItemId = bookItemModelId;
            ReaderId = readerModelId;
        }
        public Guid BookItemId { get; set; }
        public Guid ReaderId { get; set; }
    }
}