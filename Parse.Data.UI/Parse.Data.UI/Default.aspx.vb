Imports System.Net
Imports System.Net.Security
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Web.Services
Imports System.Web.Script.Services

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim request As New ParseRequest("https://api.parse.com/1/classes/Image")
        Dim ds = request.GetResponse(Of ImageResponse)().Results
        Jqgrid1.DataSource = ds
        Jqgrid1.DataBind()

        request = New ParseRequest("https://api.parse.com/1/classes/Audio")

        Dim data = request.GetResponse(Of AudioResponse)().Results
        For Each item In data
            Dim path = String.Format("~/App_Data/{0}", item.name)
            Using writer = New System.IO.FileStream(Server.MapPath(path), FileMode.Create)
                Dim bytes = Convert.FromBase64String(item.stream.Substring("data:video/3gpp;base64,".Length))
                writer.Write(bytes, 0, bytes.Length)
                writer.Flush()
            End Using

            item.stream = VirtualPathUtility.ToAbsolute(path)
        Next


        Jqgrid2.DataSource = data
        Jqgrid2.DataBind()


        'Dim image = ds(0).item
        'anchor1.Attributes("href") = image
        'img1.Src = image
    End Sub
    <WebMethod()>
    Public Function SaveImage(ByVal objectKey As String, ByVal metadata As String) As String
        Dim file As HttpPostedFile = HttpContext.Current.Request.Files("recFile")
        If (file Is Nothing) Then
            Return Nothing
        End If
        Dim targetFilePath As String = file.FileName
        file.SaveAs(targetFilePath)
        Return file.FileName.ToString()
    End Function

    <WebMethod()>
    Public Sub ShowImage()
        'anchor1.Attributes("href") = image
        'img1.Src = image

    End Sub

End Class