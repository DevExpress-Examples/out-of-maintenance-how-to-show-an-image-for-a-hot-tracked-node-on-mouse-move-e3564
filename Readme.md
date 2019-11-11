# How to show an image for a hot tracked node on mouse move


<p>You can draw an image instead of a node indicator. To do this, handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraTreeListTreeList_CustomDrawNodeIndicatortopic"><u>TreeList.CustomDrawNodeIndicator</u></a> event. To redraw a TreeList layout on a mouse move, handle the TreeList.MouseMove event, and in its handler, it is necessary to call the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraTreeListTreeList_InvalidateNodestopic"><u>TreeList.InvalidateNodes</u></a> method. To improve performance, you can call this method when only a hot tracked node was changed . To obtain a node under the mouse position, utilize the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraTreeListTreeList_CalcHitInfotopic"><u>TreeList.CalcHitInfo</u></a> method.</p>

```cs
treeList1.CalcHitInfo(treeList1.PointToClient(MousePosition)).Node
```

<p> </p>

```vb
treeList1.CalcHitInfo(treeList1.PointToClient(MousePosition)).Node
```

<p> </p><p>If you wish to execute any action if a user clicked on an image, then handle the TreeList.Click event. To verify whether or not the mouse position is over a node indicator, utilize the following code:</p>

```cs
private void treeList1_Click(object sender, EventArgs e){
    if (treeList1.CalcHitInfo(treeList1.PointToClient(MousePosition)).HitInfoType == DevExpress.XtraTreeList.HitInfoType.RowIndicator)
        MessageBox.Show("Click!");
}
```

<p> </p>

```vb
Private Sub treeList1_Click(sender As Object, e As EventArgs)
        If treeList1.CalcHitInfo(treeList1.PointToClient(MousePosition)).HitInfoType = DevExpress.XtraTreeList.HitInfoType.RowIndicator Then	
            MessageBox.Show("Click!")
        End If
End Sub
```

<p> </p>

<br/>


