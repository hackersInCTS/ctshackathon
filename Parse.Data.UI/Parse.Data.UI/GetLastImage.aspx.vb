Imports System.IO
Imports System.Threading

Public Class GetLastImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim folderPath = Server.MapPath(String.Format("~/App_Data/{0}/", Request("Directory")))
        Dim lastUpdatedFile = (New DirectoryInfo(folderPath)).GetFiles().OrderByDescending(Function(file) file.LastWriteTime).FirstOrDefault()
        If lastUpdatedFile IsNot Nothing Then
            ImageLast.ImageUrl = VirtualPathUtility.ToAppRelative(lastUpdatedFile.FullName)
        End If
    End Sub

End Class