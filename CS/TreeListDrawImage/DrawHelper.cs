using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Nodes;
using System.Windows.Forms;
using System.Drawing;

namespace TreeListDrawImage
{
    public class DrawHelper
    {
        TreeList TreeList;

        public void RegisterTreeList(TreeList treeList)
        {
            TreeList = treeList;
            SubscribeEvents();
        }

        public void RegisterTreeList(TreeList treeList, Image image)
        {
            RegisterTreeList(treeList);
            Image = image;
        }

        public Image Image { get; set; }

        public event EventHandler ImageClick;

        private void SubscribeEvents()
        {
            TreeList.CustomDrawNodeIndicator += treeList1_CustomDrawNodeIndicator;
            TreeList.Click += treeList1_Click;
            TreeList.MouseMove += treeList1_MouseMove;
        }

        private void treeList1_CustomDrawNodeIndicator(object sender, CustomDrawNodeIndicatorEventArgs e)
        {
            TreeList.ViewInfo.PaintAppearance.Row.FillRectangle(e.Cache, e.Bounds);
            if ((TreeList.ViewInfo.RowsInfo[e.Node] as RowInfo).Bounds.Contains(TreeList.PointToClient(Control.MousePosition)))
            {
                e.Graphics.DrawImage(Image, e.Bounds.Location);
            }
            e.Handled = true;
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            if (TreeList.CalcHitInfo(TreeList.PointToClient(Control.MousePosition)).HitInfoType == HitInfoType.RowIndicator)
            {
                if (ImageClick != null)
                    ImageClick(this, EventArgs.Empty);
            }
        }

        TreeListNode node;
        private void treeList1_MouseMove(object sender, MouseEventArgs e)
        {
            TreeListNode currentNode = TreeList.CalcHitInfo(TreeList.PointToClient(Control.MousePosition)).Node;
            if (currentNode != node)
            {
                node = currentNode;
                TreeList.InvalidateNodes();
            }
        }
    }
}
