Imports System.Runtime.Serialization

<DataContract()>
Public Class LossDetailResponse
    <DataMember()>
    Public Property Results As List(Of LossDetail)


End Class

<DataContract()>
Public Class LossDetail
    <DataMember()>
    Public Property PolicyKey As String
    <DataMember()>
    Public Property VehicleMake As String
    <DataMember()>
    Public Property VehicleModel As String
    <DataMember()>
    Public Property VehicleVIN As String
    <DataMember()>
    Public Property VehicleColor As String
    <DataMember()>
    Public Property Driver As String
    <DataMember()>
    Public Property PrimaryInsured As String
    <DataMember()>
    Public Property LossDetailsText As String
    <DataMember()>
    Public Property LossLocation As String
    <DataMember()>
    Public Property LossDate As String
    <DataMember()>
    Public Property LossTime As String
    <DataMember()>
    Public Property LossImages As String()
    <DataMember()>
    Public Property LossAudio As String
    <DataMember()>
    Public Property CreatedAt As String
    <DataMember()>
    Public Property UpdatedAt As String
    <DataMember()>
    Public Property objectId As String
    <DataMember()>
    Public Property DeviceId As String

End Class