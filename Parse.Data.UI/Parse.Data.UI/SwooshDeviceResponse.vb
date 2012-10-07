Imports System.Runtime.Serialization

<DataContract()>
Public Class SwooshDeviceResponse
    <DataMember()>
    Public Property Results As List(Of SwooshDevice)


End Class

<DataContract()>
Public Class SwooshDevice
    <DataMember()>
    Public Property deviceId As String
    <DataMember()>
    Public Property name As String
    <DataMember()>
    Public Property cordova As String
    <DataMember()>
    Public Property platform As String
    <DataMember()>
    Public Property uuid As String
    <DataMember()>
    Public Property version As String
    <DataMember()>
    Public Property apnsDeviceId As String
    <DataMember()>
    Public Property gcmDeviceId As String


End Class
