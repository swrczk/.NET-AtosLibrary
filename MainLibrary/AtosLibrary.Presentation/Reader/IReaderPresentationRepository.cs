using System;
using System.Collections.Generic;

namespace AtosLibrary.Presentation.Reader
{
    public interface IReaderPresentationRepository
    {
        ReaderModel Get(Guid id);

        IEnumerable<ReaderModel> GetList();
        
        IEnumerable<ReaderModel> Search(string searchText);
    }
}