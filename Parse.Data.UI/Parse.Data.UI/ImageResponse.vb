Imports System.Runtime.Serialization

<DataContract()>
Public Class ImageResponse
    <DataMember()>
    Public Property Results As List(Of Image)


End Class

<DataContract()>
Public Class Image
    <DataMember()>
    Public Property item As String
    <DataMember()>
    Public Property createdAt As String
    <DataMember()>
    Public Property updatedAt As String
    <DataMember()>
    Public Property objectId As String
End Class