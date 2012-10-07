Imports System.IO
Imports System.Threading

Public Class GetLastImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim folderPath = Server.MapPath(String.Format("~/App_Data/{0}/", Request("Directory")))
        Dim lastUpdatedFile = (New DirectoryInfo(folderPath)).GetFiles().OrderByDescending(Function(file) file.LastWriteTime).FirstOrDefault()
        If lastUpdatedFile IsNot Nothing Then
            ImageLast.ImageUrl = String.Format("~/App_Data/{0}/{1}", Request("Directory"), lastUpdatedFile.Name)
        End If
    End Sub

End Class