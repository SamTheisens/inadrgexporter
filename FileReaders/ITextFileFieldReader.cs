using System.Collections;

namespace INADRGExporter.FileReaders
{
    public interface ITextFileFieldReader : IEnumerable, IEnumerator
    {
        long Rows { get; }
        void MoveToRow(int rowNumber);
        string[] Headers { get; }
    }

}
