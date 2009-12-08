using System.Collections.Generic;

namespace InadrgExporter.FileReaderCollections
{
    public interface ITextFileFieldReaderCollection : IEnumerable<Dictionary<string,string>>, IEnumerator<Dictionary<string,string>>
    {
        long Rows { get; }
        void MoveToRow(int rowNumber);
        string[] Headers { get; }
    }
}