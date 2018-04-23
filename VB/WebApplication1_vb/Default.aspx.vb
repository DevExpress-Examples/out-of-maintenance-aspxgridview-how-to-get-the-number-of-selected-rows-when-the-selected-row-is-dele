Imports DevExpress.Web.ASPxGridView

Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If (Not IsPostBack) Then
            grid.DataBind()
        End If
    End Sub
    Private Function GetDataSource() As List(Of MyObject)
        Dim lst As List(Of MyObject) = New List(Of MyObject)()
        For i As Integer = 1 To 10
            Dim obj As MyObject = New MyObject()
            obj.ID = i
            obj.Name = String.Format("Name_{0}", i)
            lst.Add(obj)
        Next i
        Return lst
    End Function
    Private ReadOnly Property DSource() As List(Of MyObject)
        Get
            Dim lst As List(Of MyObject) = Nothing
            If Session("DSource") Is Nothing Then
                lst = GetDataSource()
                Session("DSource") = lst
            Else
                lst = TryCast(Session("DSource"), List(Of MyObject))
            End If
            Return lst
        End Get
    End Property
    Protected Sub grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        TryCast(sender, ASPxGridView).DataSource = DSource
    End Sub
    Protected Sub btnDeleteSelectedRows_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim lst As List(Of MyObject) = DSource
        Dim selectedValues As List(Of Object) = grid.GetSelectedFieldValues(grid.KeyFieldName)
        For Each value As Object In selectedValues
            Dim obj As MyObject = lst.Find(Function(s) s.ID = Convert.ToInt32(value))
            lst.Remove(obj)
        Next value
        grid.DataBind()
    End Sub

End Class