<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128638220/18.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3564)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
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


