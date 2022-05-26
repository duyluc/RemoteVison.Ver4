using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;
using System.IO;

namespace ModelTable
{
    public partial class ModelTableV1 : UserControl
    {
        #region Event
        public event EventHandler Added;
        public event EventHandler Removed;
        public event EventHandler Selected;
        protected void OnAdded(DataGridViewRow row)
        {
            Added?.Invoke(row, EventArgs.Empty);
        }
        protected void OnRemoved(DataGridViewRow row)
        {
            Removed?.Invoke(row, EventArgs.Empty);
        }
        protected void OnSelected(DataGridViewRow row)
        {
            Selected?.Invoke(row, EventArgs.Empty);
        }

        #endregion
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
        static public string DBFilePath { get; set; } = Path.Combine(DBFolderPath, "Model.db");
        public class ModelInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public ModelTableV1()
        {
            InitializeComponent();
            modifybutton(false);
        }
        public void SetupControl( List<ModelInfo> infos)
        {
            try
            {
                ShowModelInfo(infos);
            }
            catch
            {

            }
        }
        public void modifybutton(bool status)
        {
            btnAccept.Visible = status;
            btnCancel.Visible = status;
            btnAdd.Visible = !status;
            btnRemove.Visible = !status;
            if (Datagridview.RowCount == 0) return;
            Datagridview.Rows[Datagridview.RowCount - 1].ReadOnly = !status;
        }
        public bool VerifyRow(DataGridViewRow row)
        {
            if (row == null) return false;
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
                if (Datagridview.SelectedRows.Count == 0) return;
                int index = Datagridview.SelectedRows[0].Index;
                DataGridViewRow row = Datagridview.SelectedRows[0];
                if (RemoveToolBlockInfo(row.Cells[0].Value.ToString()))
                {
                    Datagridview.Rows.Remove(row);
                    OnRemoved(row);
                }
            }
            catch (Exception ex)
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
                ModelInfo info = new ModelInfo
                {
                    Name = row.Cells[0].Value.ToString()
                };
                InsertToolBlockInfo(info);
                OnAdded(row);
            }
            catch (Exception ex)
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
        public void ShowModelInfo()
        {
            if (Datagridview.InvokeRequired)
            {
                Datagridview.BeginInvoke(new Action(ShowModelInfo));
                return;
            }
            List<ModelInfo> infos = GetToolBlockInfos();
            foreach (ModelInfo info in infos)
            {
                Datagridview.Rows.Add();
                Datagridview.Rows[Datagridview.RowCount - 1].Cells[0].Value = info.Name;
            }
        }
        public void ShowModelInfo(List<ModelInfo> infos)
        {
            if (Datagridview.InvokeRequired)
            {
                Datagridview.BeginInvoke(new Action(ShowModelInfo));
                return;
            }
            foreach (ModelInfo info in infos)
            {
                Datagridview.Rows.Add();
                Datagridview.Rows[Datagridview.RowCount - 1].Cells[0].Value = info.Name;
            }
        }
        static public List<ModelInfo> GetToolBlockInfos()
        {
            List<ModelInfo> toolblockinfos;
            using (LiteDatabase db = new LiteDatabase(DBFilePath))
            {
                var col = db.GetCollection<ModelInfo>();
                toolblockinfos = col.FindAll().ToList();
                if (toolblockinfos == null)
                {
                    toolblockinfos = new List<ModelInfo>();
                }
            }
            return toolblockinfos;
        }
        static public bool RemoveToolBlockInfo(string toolblockId)
        {
            if (string.IsNullOrEmpty(toolblockId)) throw new ArgumentNullException(nameof(toolblockId));
            using (LiteDatabase db = new LiteDatabase(DBFilePath))
            {
                var col = db.GetCollection<ModelInfo>();
                ModelInfo record = col.FindOne(x => x.Name == toolblockId);
                if (record == null) return false;
                col.Delete(record.Id);
                return true;
            }
        }
        static public void InsertToolBlockInfo(ModelInfo record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
            using (LiteDatabase db = new LiteDatabase(DBFilePath))
            {
                var col = db.GetCollection<ModelInfo>();
                ModelInfo checkrecord = col.FindOne(x => x.Name == record.Name);
                if (checkrecord != null) throw new ArgumentException("ToolBlockInfo has already existed!");
                col.Insert(record);
            }
        }
        #endregion

        private void Datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnAdd.Visible == false) return;
            if (e.RowIndex < 0) return;
            OnSelected(Datagridview.Rows[e.RowIndex]);
        }
    }
}
