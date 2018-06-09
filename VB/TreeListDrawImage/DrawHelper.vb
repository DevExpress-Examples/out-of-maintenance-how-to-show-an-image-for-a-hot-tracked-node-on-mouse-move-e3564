Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.ViewInfo
Imports DevExpress.XtraTreeList.Nodes
Imports System.Windows.Forms
Imports System.Drawing

Namespace TreeListDrawImage
    Public Class DrawHelper
        Private fTreeList As TreeList

        Public Sub RegisterTreeList(ByVal treeList As TreeList)
            Me.fTreeList = treeList
            SubscribeEvents()
        End Sub

        Public Sub RegisterTreeList(ByVal treeList As TreeList, ByVal image As Image)
            RegisterTreeList(treeList)
            Me.Image = image
        End Sub
        Public Sub Unregister()
            UnsubscribeEvents()
            fTreeList = Nothing
        End Sub

        Public Property Image() As Image

        Public Event ImageClick As EventHandler

        Private Sub SubscribeEvents()
            AddHandler fTreeList.CustomDrawNodeIndicator, AddressOf treeList1_CustomDrawNodeIndicator
            AddHandler fTreeList.Click, AddressOf treeList1_Click
            AddHandler fTreeList.MouseMove, AddressOf treeList1_MouseMove
        End Sub
        Private Sub UnsubscribeEvents()
            RemoveHandler fTreeList.CustomDrawNodeIndicator, AddressOf treeList1_CustomDrawNodeIndicator
            RemoveHandler fTreeList.Click, AddressOf treeList1_Click
            RemoveHandler fTreeList.MouseMove, AddressOf treeList1_MouseMove
        End Sub

        Private Sub treeList1_CustomDrawNodeIndicator(ByVal sender As Object, ByVal e As CustomDrawNodeIndicatorEventArgs)
            Dim tree As TreeList = TryCast(sender, TreeList)
            Dim backBrush As Brush = tree.ViewInfo.PaintAppearance.Row.GetBackBrush(e.Cache)
            e.Cache.FillRectangle(backBrush, e.Bounds)
            If node Is e.Node Then
                e.Cache.DrawImage(Image, e.Bounds.Location)
            End If
            e.Handled = True
        End Sub

        Private Sub treeList1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim tree As TreeList = TryCast(sender, TreeList)
            Dim pt As Point = tree.PointToClient(Control.MousePosition)
            Dim hitInfo = tree.CalcHitInfo(pt)
            If hitInfo.HitInfoType = HitInfoType.RowIndicator Then
                RaiseEvent ImageClick(Me, EventArgs.Empty)
            End If
        End Sub

        Private node As TreeListNode
        Private Sub treeList1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim tree As TreeList = TryCast(sender, TreeList)
            Dim hitInfo = tree.CalcHitInfo(e.Location)
            Dim currentNode As TreeListNode = hitInfo.Node
            If currentNode IsNot node Then
                tree.InvalidateNode(node)
                node = currentNode
                tree.InvalidateNode(node)
            End If
        End Sub
    End Class
End Namespace
