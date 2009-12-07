using System;
using System.Collections.Generic;

namespace InadrgExporter.DataSources
{
    public interface IDataSource : IEnumerator<Dictionary<string,object>>
    {
        int Length { get;}
        void ReadRows(DateTime from, DateTime until, int startPosition, int stepSize);
    }
}