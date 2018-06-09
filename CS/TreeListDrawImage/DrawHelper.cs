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
        TreeList fTreeList;

        public void RegisterTreeList(TreeList treeList)
        {
            this.fTreeList = treeList;
            SubscribeEvents();
        }

        public void RegisterTreeList(TreeList treeList, Image image)
        {
            RegisterTreeList(treeList);
            Image = image;
        }
        public void Unregister() {
            UnsubscribeEvents();
            fTreeList = null;
        }

        public Image Image { get; set; }

        public event EventHandler ImageClick;

        private void SubscribeEvents()
        {
            fTreeList.CustomDrawNodeIndicator += treeList1_CustomDrawNodeIndicator;
            fTreeList.Click += treeList1_Click;
            fTreeList.MouseMove += treeList1_MouseMove;
        }
        private void UnsubscribeEvents() {
            fTreeList.CustomDrawNodeIndicator -= treeList1_CustomDrawNodeIndicator;
            fTreeList.Click -= treeList1_Click;
            fTreeList.MouseMove -= treeList1_MouseMove;
        }

        private void treeList1_CustomDrawNodeIndicator(object sender, CustomDrawNodeIndicatorEventArgs e)
        {
            TreeList tree = sender as TreeList;
            Brush backBrush = tree.ViewInfo.PaintAppearance.Row.GetBackBrush(e.Cache);
            e.Cache.FillRectangle(backBrush, e.Bounds);
            if (node == e.Node)
            {
                e.Cache.DrawImage(Image, e.Bounds.Location);
            }
            e.Handled = true; 
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            Point pt = tree.PointToClient(Control.MousePosition);
            var hitInfo = tree.CalcHitInfo(pt);
            if (hitInfo.HitInfoType == HitInfoType.RowIndicator)
            {
                if (ImageClick != null)
                    ImageClick(this, EventArgs.Empty);
            }
        }

        TreeListNode node;
        private void treeList1_MouseMove(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            var hitInfo = tree.CalcHitInfo(e.Location);
            TreeListNode currentNode = hitInfo.Node;
            if (currentNode != node)
            {
                tree.InvalidateNode(node);
                node = currentNode;
                tree.InvalidateNode(node);
            }
        }
    }
}
