using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSupport;

namespace InOutTerminalCollectionTable
{
    public partial class InOutTerminalCollectionTableV1: UserControl
    {

        public InOutTerminalCollectionTableV1()
        {
            InitializeComponent();
        }

        public void SetValue2View(TerminalCollection terminalCollection)
        {
            if (terminalCollection == null) throw new ArgumentNullException();
            this.Datagridview.Rows.Clear();
            foreach (KeyValuePair<string, Terminal> Ter in terminalCollection)
            {
                Terminal terminal = Ter.Value;
                DataGridViewRow newrow = new DataGridViewRow();
                DataGridViewTextBoxCell namecell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell typecell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell valuecell = new DataGridViewTextBoxCell();
                namecell.Value = terminal.Name;
                if (terminal.Type == typeof(Bitmap))
                {
                    typecell.Value = "ICogImage";
                    valuecell.Value = "ICogImage";
                }
                else
                {
                    typecell.Value = terminal.Type.ToString();
                    valuecell.Value = Convert.ChangeType(terminal.Value, terminal.Type);
                }
                newrow.Cells.AddRange(new DataGridViewCell[3] { namecell, typecell, valuecell });
                this.Datagridview.Rows.Add(newrow);
            }

        }
    }
}
