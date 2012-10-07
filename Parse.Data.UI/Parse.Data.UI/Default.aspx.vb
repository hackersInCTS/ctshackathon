Imports System.Net
Imports System.Net.Security
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Web.Services
Imports System.Web.Script.Services

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim request As New ParseRequest("https://api.parse.com/1/classes/LossDetails")
        Dim lossDetails = request.GetResponse(Of LossDetailResponse)().Results
        

        request = New ParseRequest("https://api.parse.com/1/classes/SwooshDevice")
        Dim swooshDevices = request.GetResponse(Of SwooshDeviceResponse)().Results

        Dim listNew As New List(Of LossDetailsExtended)

        

        For Each detail As LossDetail In lossDetails
            Dim gotMatch As Boolean
            For Each device As SwooshDevice In swooshDevices
                If detail.DeviceId = device.deviceId Then
                    gotMatch = True
                    listNew.Add(New LossDetailsExtended With {.GCMDeviceId = device.gcmDeviceId,
                                                                                               .PolicyKey = detail.PolicyKey,
                                                                                                 .VehicleMake = detail.VehicleMake,
                                                                                                 .VehicleModel = detail.VehicleModel,
                                                                                                 .VehicleVIN = detail.VehicleVIN,
                                                                                                 .VehicleColor = detail.VehicleColor,
                                                                                                 .Driver = detail.Driver,
                                                                                                 .PrimaryInsured = detail.PrimaryInsured,
                                                                                                 .LossDetailsText = detail.LossDetailsText,
                                                                                                 .LossLocation = detail.LossLocation,
                                                                                                 .LossDate = detail.LossDate,
                                                                                                 .LossTime = detail.LossTime,
                                                                                                 .LossImages = detail.LossImages,
                                                                                                 .LossAudio = detail.LossAudio,
                                                                                                 .CreatedAt = detail.CreatedAt,
                                                                                                 .UpdatedAt = detail.UpdatedAt,
                                                                                                 .objectId = detail.objectId,
                                                                                                 .DeviceId = detail.DeviceId})
                End If

            Next
            If Not gotMatch Then
                listNew.Add(New LossDetailsExtended With {.GCMDeviceId = "",
                                                                                               .PolicyKey = detail.PolicyKey,
                                                                                                 .VehicleMake = detail.VehicleMake,
                                                                                                 .VehicleModel = detail.VehicleModel,
                                                                                                 .VehicleVIN = detail.VehicleVIN,
                                                                                                 .VehicleColor = detail.VehicleColor,
                                                                                                 .Driver = detail.Driver,
                                                                                                 .PrimaryInsured = detail.PrimaryInsured,
                                                                                                 .LossDetailsText = detail.LossDetailsText,
                                                                                                 .LossLocation = detail.LossLocation,
                                                                                                 .LossDate = detail.LossDate,
                                                                                                 .LossTime = detail.LossTime,
                                                                                                 .LossImages = detail.LossImages,
                                                                                                 .LossAudio = detail.LossAudio,
                                                                                                 .CreatedAt = detail.CreatedAt,
                                                                                                 .UpdatedAt = detail.UpdatedAt,
                                                                                                 .objectId = detail.objectId,
                                                                                                 .DeviceId = detail.DeviceId})
            End If

        Next



        Jqgrid1.DataSource = listNew
        Jqgrid1.DataBind()

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