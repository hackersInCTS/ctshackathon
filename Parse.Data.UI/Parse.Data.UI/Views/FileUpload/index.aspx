<%@ Page Language="VB" Inherits="System.Web.Mvc.ViewPage(Of FileResult)" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>index</title>
</head>
<body>
    <div>
        <form action="/FileUpload/UploadImage/" method="post" enctype="multipart/form-data">
        <input type="file" name="imageFile" /><br />
        <input type="submit" name="Submit" id="Submit" value="Upload" />
        </form>
    </div>
</body>
</html>
