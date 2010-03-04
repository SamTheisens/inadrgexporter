using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using InadrgExporter.DataSources;

namespace INADRGExporterTestSuite.MockObjects
{
    class MockDatabaseDataSource : DatabaseDataSource
    {
        public MockDatabaseDataSource(DateTime from, DateTime until, string kdCustomer, DataTable table) : base(from, until, kdCustomer, table)
        {
        }
    }
}
