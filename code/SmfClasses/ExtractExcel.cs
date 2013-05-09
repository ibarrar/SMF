
using System;
using System.Reflection; 
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for ExtractExcel.
	/// </summary>
	public class ExtractExcel : Object
	{
		private string FileName;
        private System.Data.DataTable ReportData;

        Application oXL;
        Workbook oWB;
        Worksheet oSheet;
        Range oRng;

        public ExtractExcel(string sFileName, System.Data.DataTable dtReport)
		{
			FileName = sFileName;
			ReportData = dtReport;
		}

		
		public string WriteData()
		{
			string sReturn = "";
			
         if (System.IO.File.Exists(this.FileName))
         {
            System.IO.File.Delete(this.FileName);
         }

         try
         {

            GC.Collect();// clean up any other excel guys hangin' around...
            oXL = new Application();
            oXL.Visible = false;
            //Get a new workbook.
            oWB = (Workbook)(oXL.Workbooks.Add( Missing.Value ));
            oSheet = (Worksheet)oWB.ActiveSheet;
            //get our Data     
            System.Data.DataTable table = ReportData;
            int colIndex = 0, rowIndex = 1;

            foreach(DataColumn col in table.Columns) 
            { 
               colIndex++; 
               oSheet.Cells[rowIndex,colIndex]=col.ColumnName; 
            } 

            foreach(DataRow row in table.Rows) 
            { 
               rowIndex++; 
               colIndex=0; 
               foreach(DataColumn col in table.Columns) 
               { 
                  colIndex++; 
                  oSheet.Cells[rowIndex,colIndex]=row[col.ColumnName].ToString(); 
               } 
            }


            //Format A1:Z1 as bold, vertical alignment = center.
            oSheet.get_Range("A1", "Z1").Font.Bold = true;
            oSheet.get_Range("A1", "Z1").VerticalAlignment =XlVAlign.xlVAlignCenter;
            //AutoFit columns A:Z.
            oRng = oSheet.get_Range("A1", "Z1");
            oRng.EntireColumn.AutoFit();
            oXL.Visible = false;
            oXL.UserControl = false;	
			oWB.SaveAs( this.FileName,XlFileFormat.xlWorkbookNormal,null,null,false,false,XlSaveAsAccessMode.xlShared,false,false,null,null,null);
         }
         catch( Exception theException ) 
         {
            String errorMessage;
            errorMessage = "Error: ";
            errorMessage = String.Concat( errorMessage, theException.Message );
            errorMessage = String.Concat( errorMessage, " Line: " );
            errorMessage = String.Concat( errorMessage, theException.Source );          
            sReturn = errorMessage ;
         }
         finally
         {
            // Need all following code to clean up and extingush all references!!!
            oWB.Close(null,null,null);
            oXL.Workbooks.Close();
            oXL.Application.Quit();
            oXL.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject (oRng);
            System.Runtime.InteropServices.Marshal.ReleaseComObject (oXL);
            System.Runtime.InteropServices.Marshal.ReleaseComObject (oSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject (oWB);
            oSheet=null;
            oWB=null;
            oXL = null;
            GC.Collect();  // force final cleanup!		   
         }
			return sReturn;
		}
	}
}
