Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports System.IO

<ServiceContract()>
Public Interface IFileUploader

    <OperationContract()>
    <WebInvoke(Method:="POST", UriTemplate:="Image/{fileName}")>
    Function UploadImage(ByVal fileName As String, ByVal fileContent As Stream) As String

End Interface