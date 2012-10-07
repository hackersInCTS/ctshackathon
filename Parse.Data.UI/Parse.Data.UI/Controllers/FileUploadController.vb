﻿Imports System.Web.Mvc
Imports System.IO
Imports System.Web.Hosting

Public Class FileUploadController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /FileUpload/Details/5
    <HttpPost()>
    Function UploadImage(ByVal images As List(Of String)) As ActionResult
        CreateDirectory("~/App_Data/Image/")
        Dim filePaths = New List(Of String)
        For Each item As String In images
            Dim filePath = String.Format("~/App_Data/Image/{0}.jpg", Guid.NewGuid())

            Using destination = New FileStream(HostingEnvironment.MapPath(filePath), FileMode.Create)
                Dim bytes = Convert.FromBase64String(item)
                destination.Write(bytes, 0, bytes.Length)
                destination.Flush()
                destination.Close()
            End Using

            filePaths.Add(filePath)
        Next

        Return Json(filePaths)
    End Function

    Private Shared Sub CreateDirectory(ByVal folder As String)
        Dim directory = New DirectoryInfo(HostingEnvironment.MapPath(folder))
        If Not directory.Exists Then
            directory.Create()
        End If
    End Sub

End Class
