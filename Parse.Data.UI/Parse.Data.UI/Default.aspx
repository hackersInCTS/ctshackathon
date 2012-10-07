<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="Parse.Data.UI._Default"  %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
     ....
    <link rel="stylesheet" type="text/css" media="screen" href="Styles/redmond/jquery-ui-1.8.24.custom.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="Styles/ui.jqgrid.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="Styles/chocolat.css" />
    ...
    <script src="Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.chocolat.js" type="text/javascript"></script>
   <script src="Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/i18n/grid.locale-en.js" type="text/javascript"></script>
    <script src="Scripts/jquery.jqGrid.min.js" type="text/javascript"></script>
    
    ...

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="Button1" runat="server" Text="Refresh" OnClientClick="javascript:forceSort();" />
    <cc1:JQGrid ID="Jqgrid1" runat="server">
    <ClientSideEvents  RowSelect="getRowData"/>
    <Columns>
        
        <cc1:JQGridColumn DataField="PolicyKey"  ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="LossLocation"  ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="LossDate"  ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="LossTime"  ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="VehicleMake"  ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="VehicleModel"  ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="VehicleColor" Visible=false  ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="VehicleVIN" Visible=false  ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="LossAudio" Visible=false  ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="LossImages" Visible=false ></cc1:JQGridColumn>
        
    </Columns>
    </cc1:JQGrid>
    
    
    <%--Audio:
    <cc1:JQGrid ID="Jqgrid2" runat="server">
    <ClientSideEvents  RowSelect="getAudioData"/>
    <Columns>
        <cc1:JQGridColumn DataField="objectId"></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="createdAt"></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="updatedAt"></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="stream" Visible=false ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="type"  ></cc1:JQGridColumn>
    </Columns>
    </cc1:JQGrid>--%>
    <script>
        function forceSort() {
            var grid = $("#<%= JQGrid1.ClientID %>");
            grid.sortGrid("LossDate", true);
        }
        $(function () {
            $("#tabs").tabs();
        });
        $(function () {
            $('#photos a').Chocolat();

        });

        function getRowData(id) {            
                var grid = jQuery("#<%= JQGrid1.ClientID %>");
                $('[id$="PolicyNumber"]').text(grid.getRowData(id)["PolicyKey"]);
                $('[id$="VehicleMakeLabel"]').text(grid.getRowData(id)["VehicleMake"]);
                $('[id$="VehicleModelLabel"]').text(grid.getRowData(id)["VehicleModel"]);
                $('[id$="VehicleColor"]').text(grid.getRowData(id)["VehicleColor"]);
                $('[id$="VIN"]').text(grid.getRowData(id)["VehicleVIN"]);
                $('[id$="LossLocationLabel"]').text(grid.getRowData(id)["LossLocation"]);
                $('[id$="LossDateLabel"]').text(grid.getRowData(id)["LossDate"]);
                $('[id$="LossTimeLabel"]').text(grid.getRowData(id)["LossTime"]);

                var grid = jQuery("#<%= JQGrid1.ClientID %>");
                var image = grid.getRowData(id)["LossImage"];                
                $('[id*="img1"]')[0].src = image;
                $('[id*="anchor1"]')[0].href = image;                
                var stream = grid.getRowData(id)["LossAudio"];  
                var type = "";

                var audio = $("#audio1");
                audio.attr("src", stream).attr("type", type);
                /****************/
                audio[0].load();
                audio[0].play();
//                debugger;
//                $.ajax({
//                    type: "POST",
//                    url: "Default.aspx/ShowImage",
//                    contentType: "application/json; charset=utf-8",
//                    dataType: "json",
//                    //data: "{ 'objectId':'" + grid.getRowData(id)["objectId"] + "', 'image':'" + grid.getRowData(id)["item"] + "'}",
//                    data:"{}",
//                    error: function (jqXHR, textStatus, errorThrown) { debugger; }
//                }).done(function () {
//                    
//                    alert("Data Shown!");
//                });
            
        }
        
	</script>



<div class="LossInfoSection">

<div id="tabs">
	<ul>
		<li><a href="#tabs-1">Loss Iformation</a></li>		
		<li><a href="#tabs-2">Photos</a></li>
        <li><a href="#tabs-3">Audio Notes</a></li>
        <li><a href="#tabs-4">Policy Information</a></li>
	</ul>
	<div id="tabs-1">
		<p>
        <asp:Label ID="LossLocationCaption" runat="server" Text="Loss Location:"></asp:Label>
         <asp:Label ID="LossLocationLabel" runat="server" Text=""></asp:Label>        
        </p>
		<p>
        <asp:Label ID="LossDateCaption" runat="server" Text="Loss Date:"></asp:Label>
         <asp:Label ID="LossDateLabel" runat="server" Text=""></asp:Label>  
        </p>
        <p>
        <asp:Label ID="LossTimeCaption" runat="server" Text="Loss Time:"></asp:Label>
         <asp:Label ID="LossTimeLabel" runat="server" Text=""></asp:Label>  
        </p>
        
	</div>
	<div id="tabs-2">
		<p id="photos">
        <a href="#" title="Rose" rel="title1" id="anchor1" runat="server" >
		<img width="100" src="" id ="img1" runat="server"/>
	    </a>
	
        </p>
	</div>
	<div id="tabs-3">
		<p>
        <audio controls="controls" id="audio1" preload="auto">
        <source src="recording-12949505.3gpp" type="audio/3gpp" />
        </audio>
        </p>
        
	</div>
    <div id="tabs-4">
		<p>
        <asp:Label ID="PolicyNumberCaption" runat="server" Text="Policy Number:"></asp:Label>
         <asp:Label ID="PolicyNumber" runat="server" Text=""></asp:Label>        
        </p>
		<p>
        <asp:Label ID="VehicleMakeCaption" runat="server" Text="Vehicle Make:"></asp:Label>
         <asp:Label ID="VehicleMakeLabel" runat="server" Text=""></asp:Label>  
        </p>
        <p>
        <asp:Label ID="VehicleModelCaption" runat="server" Text="Vehicle Model:"></asp:Label>
         <asp:Label ID="VehicleModelLabel" runat="server" Text=""></asp:Label>  
        </p>
        <p>
        <asp:Label ID="VINCaption" runat="server" Text="VIN:"></asp:Label>
         <asp:Label ID="VIN" runat="server" Text=""></asp:Label>  
        </p>
        <p>
        <asp:Label ID="VehicleColorCaption" runat="server" Text="Vehicle Color:"></asp:Label>
         <asp:Label ID="VehicleColor" runat="server" Text=""></asp:Label>  
        </p>
	</div>
</div>

</div><!-- End demo -->


</asp:Content>
