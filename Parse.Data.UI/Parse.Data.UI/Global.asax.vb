Imports System.Web.SessionState
Imports System.Web.Routing
Imports System.ServiceModel.Activation
Imports System.Web.Mvc

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        'RouteTable.Routes.Add(New ServiceRoute("FileUploader", New WebServiceHostFactory(), GetType(FileUploader)))
        RegisterRoutes(RouteTable.Routes)
    End Sub

    Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
    End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute("Default", "{controller}/{action}/{id}",
                        New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional})
        routes.MapRoute("FileUpload", "{controller}/{action}",
                       New With {.controller = "FileUpload", .action = "Index"})

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class