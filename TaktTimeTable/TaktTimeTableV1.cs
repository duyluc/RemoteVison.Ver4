using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaktTimeTable
{
    public partial class TaktTimeTableV1: UserControl
    {
        public class Subject
        {
            public string Name { get; set; }
            public long Time { get; set; }
            public bool EnableAccumulate { get; set;}
        }
        public TaktTimeTableV1()
        {
            InitializeComponent();
            DataGridViewRow newrow = new DataGridViewRow();
            DataGridViewTextBoxCell namecell = new DataGridViewTextBoxCell();
            namecell.Value = "Total";
            newrow.Cells.Add(namecell);
            DataGridViewTextBoxCell timecell = new DataGridViewTextBoxCell();
            timecell.Value = "0";
            newrow.Cells.Add(timecell);
            DataGridViewCheckBoxCell accell = new DataGridViewCheckBoxCell();
            accell.Value = true;
            newrow.Cells.Add(accell);
            this.Datagridview.Rows.Add(newrow);
        }
        public void AddTime(string name, long value, bool enableaccumulate)
        {
            if (this.Datagridview.InvokeRequired)
            {
                this.Datagridview.BeginInvoke(new Action<string, long, bool>(AddTime), name, value, enableaccumulate);
                return;
            }
            lock (this.Datagridview)
            {
                Subject _subject = new Subject
                {
                    Name = name,
                    Time = value,
                    EnableAccumulate = enableaccumulate
                };
                bool found = false;
                foreach (DataGridViewRow row in this.Datagridview.Rows)
                {
                    if (row.Cells[0].Value.ToString() == _subject.Name)
                    {
                        row.Cells[1].Value = _subject.Time;
                        found = true;
                    }
                }
                if (!found)
                {
                    DataGridViewRow newrow = new DataGridViewRow();
                    DataGridViewTextBoxCell namecell = new DataGridViewTextBoxCell();
                    namecell.Value = _subject.Name;
                    newrow.Cells.Add(namecell);
                    DataGridViewTextBoxCell timecell = new DataGridViewTextBoxCell();
                    timecell.Value = _subject.Time;
                    newrow.Cells.Add(timecell);
                    DataGridViewCheckBoxCell accell = new DataGridViewCheckBoxCell();
                    accell.Value = _subject.EnableAccumulate;
                    newrow.Cells.Add(accell);
                    this.Datagridview.Rows.Insert(this.Datagridview.Rows.Count - 1, newrow);
                }
                long total = 0;
                foreach (DataGridViewRow row in this.Datagridview.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "Total") continue;
                    long time = 0;
                    try
                    {
                        if ((bool)row.Cells[2].Value)
                        {
                            time = Convert.ToInt64(row.Cells[1].Value);
                            total += time;
                        }
                    }
                    catch (Exception ex)
                    {
                        string exx = ex.Message;
                    }

                }
                this.Datagridview.Rows[this.Datagridview.Rows.Count - 1].Cells[1].Value = total;
            }
        }
    }
}
