using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using System.Data;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace BudgetWeb.BLL
{
    public class ImportFinaDataLogic
    {
        public static DataTable GetDTBySheetname(string sname, byte[] filename,int rowIndex,int cellNum)
        {
            DataTable dt = new DataTable();
            Dictionary<string, int> dic = new Dictionary<string, int>();
            if (ExcelRender.HasData(new MemoryStream(filename)))
            {
                IWorkbook wk = new HSSFWorkbook(new MemoryStream(filename));
                for (int i = 0; i < wk.NumberOfSheets; i++)
                {
                    ISheet sheet = wk.GetSheetAt(i);
                    string str = sheet.SheetName;
                    dic.Add(str, i);
                }
            }
            dt = ExcelRender.RenderFromExcel1(new MemoryStream(filename), dic[sname],rowIndex,cellNum);
            return dt;
        }
       
    }
}
