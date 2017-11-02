using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace EXCELlentKnowledge
{
    class Program
    {
        static void Main(string[] args)
        {
            string appPath = Environment.CurrentDirectory;
            string fileName = appPath + @"\sample_table.xlsx";            

            object[,] excelData;
            bool isRead = ReadExcelFile(fileName, out excelData);

            if(isRead)
            {
                PrintExcelData(excelData);
            }
        }
        
        public static bool ReadExcelFile(string fname, out object[,] valueArray)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range oRng = null;
            object misValue = System.Reflection.Missing.Value;

            try
            {
                //Start Excel and get Application object.
                xlApp = new Microsoft.Office.Interop.Excel.Application();

                xlApp.Visible = false;
                xlApp.DisplayAlerts = false;

                // Open the Excel file.
                // You have pass the full path of the file.
                wb = xlApp.Workbooks.Open(fname);

                // Get the first worksheet.
                ws = (Worksheet)wb.Worksheets.get_Item(1);

                // Get the range of cells which has data.
                Range xlRange = ws.UsedRange;
                //int rowCount = xlRange.Rows.Count;
                //int colCount = xlRange.Columns.Count;

                // Get an object array of all of the cells in the worksheet with their values.
                valueArray = (object[,])xlRange.get_Value(
                            Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault);
                
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);

                valueArray = null;
                return false;
            }
            finally
            {
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (oRng != null)
                    Marshal.ReleaseComObject(oRng);
                if (ws != null)
                    Marshal.ReleaseComObject(ws);

                // Close the Workbook.
                if (wb != null)
                {
                    wb.Close(false, misValue, misValue);
                    // Relase COM Object by decrementing the reference count.
                    Marshal.ReleaseComObject(wb);
                }

                // Close Excel application.
                xlApp.Quit();

                // Release COM object.
                Marshal.FinalReleaseComObject(xlApp);
            }
        }

        private static void PrintExcelData(object[,] excelData)
        {
            for(int currentRow = 1; currentRow <= excelData.GetLength(0); currentRow++)
            {
                StringBuilder outputLine = new StringBuilder();
                for(int currentCol = 1; currentCol <= excelData.GetLength(1); currentCol++)
                {
                    outputLine.Append(excelData[currentRow, currentCol] + "|");
                }

                Console.WriteLine(outputLine);
            }            
        }
    }
}
