using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Ver1
{
    public partial class FrmSettingToolBlock : Form
    {
        Dictionary<string,CogToolBlock> ToolBlocks { get; set; }
        public FrmSettingToolBlock(
            List<ToolBlockSetting.ToolBlockSetting.ToolBlockInfo> infos, 
            Dictionary<string,CogToolBlock> Tools)
        {
            InitializeComponent();
            this.ToolBlockSettingControl.SetupControl(infos, new Dictionary<string, CogToolBlock>());
        }
    }
}
