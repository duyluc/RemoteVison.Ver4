using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ToolBlockInfoTable
{
    public partial class ToolBlockInfoTable : UserControl
    {
        static private string _dBFolderPath = ".\\Database";
        public static string DBFolderPath
        {
            get
            {
                if (!Directory.Exists(_dBFolderPath))
                    Directory.CreateDirectory(_dBFolderPath);
                return _dBFolderPath;
            }

            set
            {
                _dBFolderPath = value;
            }
        }
        static public string DBFilePath { get; set; } = Path.Combine(DBFolderPath, "ToolBlockInfo.db");
        public class ToolBlockInfo
        {
            public int Id { get; set; }
            public string ToolBlockID { get; set; }
            public string ToolBlockPath { get; set; }
        }
        public ToolBlockInfoTable()
        {
            InitializeComponent();
            ShowToolBlockInfos();
            Datagridview.ReadOnly = false;
            modifybutton(false);
            
        }
        public void modifybutton(bool status)
        {
            this.btnAccept.Visible = status;
            this.btnCancel.Visible = status;
            this.btnAdd.Visible = !status;
            this.btnRemove.Visible = !status;
            if (Datagridview.RowCount == 0) return;
            Datagridview.Rows[Datagridview.RowCount - 1].ReadOnly = !status;
        }
        public bool VerifyRow(DataGridViewRow row)
        {
            if(row == null) return false;
            if (row.Cells[0].Value == null) return false;
            if (string.IsNullOrEmpty(row.Cells[0].Value.ToString())) return false;
            return true;
        }
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Datagridview.Rows.Add();
            modifybutton(true);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Datagridview.SelectedRows.Count == 0) return;
                int index = this.Datagridview.SelectedRows[0].Index;
                DataGridViewRow row = Datagridview.SelectedRows[0];
                if (RemoteToolBlockInfo(row.Cells[0].Value.ToString()))
                {
                    Datagridview.Rows.Remove(row);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            modifybutton(false);
            try
            {
                DataGridViewRow row = Datagridview.Rows[Datagridview.RowCount - 1];
                if (!VerifyRow(row))
                {
                    throw new ArgumentException("New row is invalid!");
                }
                ToolBlockInfo info = new ToolBlockInfo
                {
                    ToolBlockID = row.Cells[0].Value.ToString(),
                    ToolBlockPath = "test"
                };
                InsertToolBlockInfo(info);
            }
            catch(Exception ex)
            {
                Datagridview.Rows.RemoveAt(Datagridview.RowCount - 1);
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            modifybutton(false);
            Datagridview.Rows.RemoveAt(Datagridview.RowCount - 1);
        }
        #endregion
        #region Database Provider
        public void ShowToolBlockInfos()
        {
            if (Datagridview.InvokeRequired)
            {
                Datagridview.BeginInvoke(new Action(ShowToolBlockInfos));
                return;
            }
            List<ToolBlockInfo> toolblockinfos = GetToolBlockInfos();
            foreach (ToolBlockInfo info in toolblockinfos)
            {
                Datagridview.Rows.Add();
                Datagridview.Rows[Datagridview.RowCount - 1].Cells[0].Value = info.ToolBlockID;
            }
        }
        static public List<ToolBlockInfo> GetToolBlockInfos()
        {
            List<ToolBlockInfo> toolblockinfos;
            using (LiteDatabase db = new LiteDatabase(DBFilePath))
            {
                var col = db.GetCollection<ToolBlockInfo>();
                toolblockinfos = col.FindAll().ToList();
                if (toolblockinfos == null)
                {
                    toolblockinfos = new List<ToolBlockInfo>();
                }
            }
            return toolblockinfos;
        }
        static public bool RemoteToolBlockInfo(string toolblockId)
        {
            if (string.IsNullOrEmpty(toolblockId)) throw new ArgumentNullException(nameof(toolblockId));
            using (LiteDatabase db = new LiteDatabase(DBFilePath))
            {
                var col = db.GetCollection<ToolBlockInfo>();
                ToolBlockInfo record = col.FindOne(x => x.ToolBlockID == toolblockId);
                if (record == null) return false;
                col.Delete(record.Id);
                return true;
            }
        }
        static public void InsertToolBlockInfo(ToolBlockInfo record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
            using (LiteDatabase db = new LiteDatabase(DBFilePath))
            {
                var col = db.GetCollection<ToolBlockInfo>();
                ToolBlockInfo checkrecord = col.FindOne(x => x.ToolBlockID == record.ToolBlockID);
                if (checkrecord != null) throw new ArgumentException("ToolBlockInfo has already existed!");
                col.Insert(record);
            }
        }
        #endregion
    }
}
