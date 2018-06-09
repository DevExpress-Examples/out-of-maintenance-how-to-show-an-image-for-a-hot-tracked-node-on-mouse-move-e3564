using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Nodes;

namespace TreeListDrawImage
{
    public partial class Form1 : Form
    {
        DrawHelper helper;
        public Form1()
        {
            InitializeComponent();
            AddNodes();
            helper = new DrawHelper();
            helper.RegisterTreeList(treeList1, TreeListDrawImage.Properties.Resources.Asphalt_World___16x16);
            helper.ImageClick += helper_ImageClick;
        }

        void helper_ImageClick(object sender, EventArgs e)
        {
            MessageBox.Show("Click!");
        }

        void AddNodes()
        {
            for (int i = 0; i < 10; i++)
            {
                treeList1.AppendNode(new object[] { string.Format("Node {0}", i) }, -1);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            helper.ImageClick -= helper_ImageClick;
            helper.Unregister();
            base.OnFormClosing(e);
        }
    }
}
