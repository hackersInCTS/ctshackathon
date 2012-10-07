Imports System.ServiceModel.Activation
Imports System.IO

<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)>
Public Class FileUploader
    Implements IFileUploader

    Public Function UploadImage(fileName As String, ByVal fileContent As Stream) As String Implements IFileUploader.UploadImage
        Dim filePath = String.Format("~/App_Data/Image/{0}_{1}", Guid.NewGuid(), fileName)

        Using destination = New FileStream(filePath, FileMode.Create)
            fileContent.CopyTo(destination)
            destination.Flush()
            destination.Close()
        End Using

        Return filePath
    End Function

End Class
