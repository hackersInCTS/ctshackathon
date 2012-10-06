Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Net

Public Class ParseRequest

    Private request As WebRequest

    Public Sub New(ByVal restQuery As String)

        Me.request = WebRequest.Create(restQuery)
        request.Method = "GET"
        request.ContentType = "application/x-www-form-urlencoded"
        request.Headers.Add(String.Format("X-Parse-Application-Id:{0}", "yMQl1IsnmiQZGS8TC1Y3mt4OQ05KwVxAZUvCvlD7"))
        request.Headers.Add(String.Format("X-Parse-REST-API-Key:{0}", "b5UuCBaHwYL0ohysqj8OdngQGQ1NVQStcxXchYp0"))
    End Sub

    Public Function GetResponse(Of t)() As t
        Dim response As WebResponse = request.GetResponse()
        Dim dataStream As Stream = response.GetResponseStream()
        Dim sr As New StreamReader(dataStream)
        Dim s As String = sr.ReadToEnd


        Dim serializer As New JavaScriptSerializer
        Return serializer.Deserialize(Of t)(s)



    End Function

End Class
