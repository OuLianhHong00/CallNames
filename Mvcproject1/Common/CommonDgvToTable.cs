using System;
using System.Data;
using System.Windows.Forms;
namespace Common
{
    public class CommonDgvToTable
    {
        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            //列强制装换
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[i].Name.ToString());
                dt.Columns.Add(dc);
            }
            Console.WriteLine(dgv.Rows.Count.ToString(), dgv.Columns.Count);
            //循环行数
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dr[j] = dgv.Rows[i].Cells[j].Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
