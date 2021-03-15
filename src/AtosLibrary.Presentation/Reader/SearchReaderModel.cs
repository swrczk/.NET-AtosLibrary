using System;
using System.Collections.Generic;

namespace AtosLibrary.Presentation.Reader
{
    public class SearchReaderModel
    {
        public int NumberOfSearched { get; set; }
        public int AllReaders { get; set; }
        public IList<ReaderModel> Readers { get; set; }
        public SearchReaderModel(int numberOfSearched, int allReaders, IList<ReaderModel> readers)
        {
            NumberOfSearched = numberOfSearched;
            AllReaders = allReaders;
            Readers = readers;
        }
        
    }

}
