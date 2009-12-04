using System;
using System.Collections;

namespace InadrgExporter.FileReaders
{
    public interface ITextFileFieldReader : IEnumerable, IEnumerator, IDisposable
    {
        long Rows { get; }
        void MoveToRow(int rowNumber);
        string[] Headers { get; }
    }

}
