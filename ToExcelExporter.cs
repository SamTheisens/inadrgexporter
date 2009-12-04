using System.ComponentModel;
using DataTable=System.Data.DataTable;

namespace InadrgExporter
{
    class ToExcelExporter
    {
        public static void WriteToExcelSpreadsheet(string fileName, DataTable dt, BackgroundWorker worker)
        {

            //string filepath = fileName;
            //var ExlApp = new Application();

            //Object missing = System.Reflection.Missing.Value;

            //try
            //{
            //    if (ExlApp == null)
            //    {
            //        throw (new Exception("Unable to Start Microsoft Excel"));
            //    }

            //    ExlApp.DisplayAlerts = true;

            //    if (!File.Exists(filepath))
            //    {
            //        ExlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            //    }
            //    else
            //    {
            //        ExlApp.Workbooks._Open(filepath, missing, missing, missing, missing, missing, missing,
            //                               missing, missing, missing, missing, missing, missing);
            //    }

            //    ExlApp.SheetsInNewWorkbook = 1;


            //    //For displaying the column name in the the excel file.
            //    Range header = ExlApp.Cells.get_Range(ExlApp.Cells[1, 1], ExlApp.Cells[1, dt.Columns.Count + 1]);
            //    var cols = new object[dt.Columns.Count];
            //    dt.Columns.CopyTo(cols, 0);

            //    header.Font.Bold = true;

            //    int iCol;
            //    for (iCol = 0; iCol < dt.Columns.Count; iCol++)
            //    {
            //        //'clear column name before setting a new value
            //        ExlApp.Cells[1, iCol + 1] = "";
            //        ExlApp.Cells[1, iCol + 1] = dt.Columns[iCol].ColumnName;
            //    }

            //    for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
            //    {
            //        Range range = ExlApp.Cells.get_Range(ExlApp.Cells[iRow + 2, 1],
            //                                                ExlApp.Cells[iRow + 2, dt.Rows[iRow].ItemArray.Length
            //                                                    ]);
            //        var rowToString = new List<object>();

                    
            //        foreach (object o in dt.Rows[iRow].ItemArray)
            //        {
            //            if (o is DateTime)
            //            {
            //                rowToString.Add(GrouperHelper.ToSQLDate((DateTime) o));
            //            }
            //            else if (o is int)
            //            {
            //                rowToString.Add((int) o);
            //            }
            //            else
            //            {
            //                rowToString.Add(o);
            //            }
            //        }
            //        range.Value2 = rowToString.ToArray();

            //        worker.ReportProgress((int)((float)iRow / dt.Rows.Count * 100.0));
            //    }

            //    if (File.Exists(filepath))
            //    {
            //        ExlApp.ActiveWorkbook.Save();
            //    }
            //    else
            //    {
            //        ExlApp.ActiveWorkbook.SaveAs(filepath, missing, missing, missing, missing, missing,
            //                                     XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing,
            //                                     missing);
            //    }

            //    ExlApp.ActiveWorkbook.Close(true, missing, missing);
            //}

            //catch (System.Runtime.InteropServices.COMException ex)
            //{
            //    Console.Write("ERROR: " + ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.Write("ERROR: " + ex.Message);
            //}
            //finally
            //{
            //    ExlApp.Quit();
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(ExlApp);
            //}
        }

    }
}
