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
        Private TreeList As TreeList

        Public Sub RegisterTreeList(ByVal treeList As TreeList)
            Me.TreeList = treeList
            SubscribeEvents()
        End Sub

        Public Sub RegisterTreeList(ByVal treeList As TreeList, ByVal image As Image)
            RegisterTreeList(treeList)
            Me.Image = image
        End Sub

        Public Property Image() As Image

        Public Event ImageClick As EventHandler

        Private Sub SubscribeEvents()
            AddHandler TreeList.CustomDrawNodeIndicator, AddressOf treeList1_CustomDrawNodeIndicator
            AddHandler TreeList.Click, AddressOf treeList1_Click
            AddHandler TreeList.MouseMove, AddressOf treeList1_MouseMove
        End Sub

        Private Sub treeList1_CustomDrawNodeIndicator(ByVal sender As Object, ByVal e As CustomDrawNodeIndicatorEventArgs)
            TreeList.ViewInfo.PaintAppearance.Row.FillRectangle(e.Cache, e.Bounds)
            If (TryCast(TreeList.ViewInfo.RowsInfo(e.Node), RowInfo)).Bounds.Contains(TreeList.PointToClient(Control.MousePosition)) Then
                e.Graphics.DrawImage(Image, e.Bounds.Location)
            End If
            e.Handled = True
        End Sub

        Private Sub treeList1_Click(ByVal sender As Object, ByVal e As EventArgs)
            If TreeList.CalcHitInfo(TreeList.PointToClient(Control.MousePosition)).HitInfoType = HitInfoType.RowIndicator Then
                RaiseEvent ImageClick(Me, EventArgs.Empty)
            End If
        End Sub

        Private node As TreeListNode
        Private Sub treeList1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim currentNode As TreeListNode = TreeList.CalcHitInfo(TreeList.PointToClient(Control.MousePosition)).Node
            If currentNode IsNot node Then
                node = currentNode
                TreeList.InvalidateNodes()
            End If
        End Sub
    End Class
End Namespace
