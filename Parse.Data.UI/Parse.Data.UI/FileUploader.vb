Imports System.ServiceModel.Activation
Imports System.IO
Imports System.Web.Hosting

<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)>
Public Class FileUploader
    Implements IFileUploader

    Public Function UploadImage(fileName As String, ByVal fileContent As Stream) As String Implements IFileUploader.UploadImage
        Dim filePath = String.Format("~/App_Data/Image/{0}_{1}", Guid.NewGuid(), fileName)

        Try
            Using destination = New FileStream(HostingEnvironment.MapPath(filePath), FileMode.Create)
                fileContent.CopyTo(destination)
                destination.Flush()
                destination.Close()
            End Using
        Catch ex As Exception
            Return ex.Message
        End Try

        Return filePath
    End Function

End Class
