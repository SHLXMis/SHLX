using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data;

namespace Redsoft
{
    public class ExcelHelper
    {
        public static void GridToExcel(DataGridView list,string xlsFileName)
        {
            Excel.Application AppExcel = null;
            Excel.Worksheet SheetExcel = null;
         
            if (AppExcel == null)
                AppExcel = new Excel.ApplicationClass();
          
            int StartRow = 1;			//开始行(0Base)
            int StartCol = 1;			//开始列(0Base)
  
            if (AppExcel.Workbooks.Count == 0)
                AppExcel.Workbooks.Add("");

            SheetExcel = (Excel.Worksheet)AppExcel.Workbooks[1].Worksheets[1];

            ((Excel._Worksheet)SheetExcel).Activate();
            Excel.Range range;
            //写入列名称
            int totalCols = 0;
            int k = 0;
            for (int j = 0; j < list.Columns.Count; j++)
            {
                if (list.Columns[j].Width == 0)
                    continue;
                SheetExcel.Cells[StartRow, k + StartCol] = list.Columns[j].HeaderText;
                range = (Excel.Range)SheetExcel.Cells[StartRow, j + StartCol];

                range.BorderAround("1", Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                k++;
                totalCols++;
            }
            StartRow += 1;

            //写入数据
            string[,] saRet = new string[list.Rows.Count, totalCols];
            for (int i = 0; i < list.Rows.Count; i++)
            {
                k = 0;
                for (int j = 0; j < list.Columns.Count; j++)
                {
                    if (list.Columns[j].Width == 0)
                        continue;
                    saRet[i, k] = GetListItem(list, i, j);
                    k++;
                }
            }

            range = (Excel.Range)SheetExcel.Cells[StartRow, StartCol];
            range = range.get_Resize(list.Rows.Count, totalCols);
            range.Borders.LineStyle = "1";
            range.Borders.Weight = Excel.XlBorderWeight.xlThin;
            range.set_Value(Missing.Value, saRet);
           

            SheetExcel.UsedRange.Columns.AutoFit();
            SheetExcel.UsedRange.RowHeight = 21;
            SheetExcel.UsedRange.Rows.AutoFit();
           
            AppExcel.Visible = true;

            //如果文件存在，删除文件
            if (System.IO.File.Exists(xlsFileName))
                System.IO.File.Delete(xlsFileName);

            //保存文件
            AppExcel.Workbooks[1].SaveCopyAs(xlsFileName);

            AppExcel.Visible = true;
           
        }
        public static string GetListItem(DataGridView list, int i, int j)
        {
            return Common.GetString(list.Rows[i].Cells[j].Value);    
        }
        public static string GetListItem(DataTable list, int i, int j)
        {
            return Common.GetString(list.Rows[i][j]);
        }
        public static void TableToExcel(DataTable list, string xlsFileName)
        {
            Excel.Application AppExcel = null;
            Excel.Worksheet SheetExcel = null;

            if (AppExcel == null)
                AppExcel = new Excel.ApplicationClass();

            int StartRow = 1;			//开始行(0Base)
            int StartCol = 1;			//开始列(0Base)

            if (AppExcel.Workbooks.Count == 0)
                AppExcel.Workbooks.Add("");

            SheetExcel = (Excel.Worksheet)AppExcel.Workbooks[1].Worksheets[1];

            ((Excel._Worksheet)SheetExcel).Activate();
            Excel.Range range;
            //写入列名称
            int totalCols = 0;
            int k = 0;
            for (int j = 0; j < list.Columns.Count; j++)
            {
                
                SheetExcel.Cells[StartRow, k + StartCol] = list.Columns[j].ColumnName;
                range = (Excel.Range)SheetExcel.Cells[StartRow, j + StartCol];

                range.BorderAround("1", Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                k++;
                totalCols++;
            }
            StartRow += 1;

            //写入数据
            string[,] saRet = new string[list.Rows.Count, totalCols];
            for (int i = 0; i < list.Rows.Count; i++)
            {
                k = 0;
                for (int j = 0; j < list.Columns.Count; j++)
                {
                    
                    saRet[i, k] = GetListItem(list, i, j);
                    k++;
                }
            }

            range = (Excel.Range)SheetExcel.Cells[StartRow, StartCol];
            range = range.get_Resize(list.Rows.Count, totalCols);
            range.Borders.LineStyle = "1";
            range.Borders.Weight = Excel.XlBorderWeight.xlThin;
            range.set_Value(Missing.Value, saRet);

            AppExcel.Visible = true;

            //如果文件存在，删除文件
            if (System.IO.File.Exists(xlsFileName))
                System.IO.File.Delete(xlsFileName);

            //保存文件
            AppExcel.Workbooks[1].SaveCopyAs(xlsFileName);

            AppExcel.Visible = true;

        }
    }
}
