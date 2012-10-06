Imports System.Runtime.Serialization

<DataContract()>
Public Class AudioResponse
    <DataMember()>
    Public Property Results As List(Of Audio)


End Class

<DataContract()>
Public Class Audio
    <DataMember()>
    Public Property stream As String
    <DataMember()>
    Public Property name As String
    <DataMember()>
    Public Property type As String
    <DataMember()>
    Public Property size As Integer
    <DataMember()>
    Public Property createdAt As String
    <DataMember()>
    Public Property updatedAt As String
    <DataMember()>
    Public Property objectId As String
End Class
