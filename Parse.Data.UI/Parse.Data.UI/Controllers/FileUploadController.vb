Imports System.Web.Mvc
Imports System.IO
Imports System.Web.Hosting

Public Class FileUploadController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /FileUpload/Details/5
    Function UploadImage() As ActionResult
        Try
            CreateDirectory("~/App_Data/Image/")
            For Each item As HttpPostedFileBase In Request.Files
                Dim filePath = String.Format("~/App_Data/Image/{0}_{1}", Guid.NewGuid(), item.FileName)

                Using destination = New FileStream(HostingEnvironment.MapPath(filePath), FileMode.Create)
                    item.InputStream.CopyTo(destination)
                    destination.Flush()
                    destination.Close()
                End Using
            Next

        Catch ex As Exception
            Return Json(ex.Message)
        End Try

        Return View()
    End Function

    Private Shared Sub CreateDirectory(ByVal folder As String)
        Dim directory = New DirectoryInfo(HostingEnvironment.MapPath(folder))
        If Not directory.Exists Then
            directory.Create()
        End If
    End Sub

End Class
