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
    Images:
    <cc1:JQGrid ID="Jqgrid1" runat="server">
    <ClientSideEvents  RowSelect="getRowData"/>
    <Columns>
        <cc1:JQGridColumn DataField="objectId"></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="createdAt"></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="updatedAt"></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="item" Visible=false ></cc1:JQGridColumn>
    </Columns>
    </cc1:JQGrid>
    Audio:
    <cc1:JQGrid ID="Jqgrid2" runat="server">
    <ClientSideEvents  RowSelect="getAudioData"/>
    <Columns>
        <cc1:JQGridColumn DataField="objectId"></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="createdAt"></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="updatedAt"></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="stream" Visible=false ></cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="type"  ></cc1:JQGridColumn>
    </Columns>
    </cc1:JQGrid>
    <script>
        $(function () {
            $("#tabs").tabs();
        });
        $(function () {
            $('#photos a').Chocolat();

        });
       
        function getRowData(id) {
            
                var grid = jQuery("#<%= JQGrid1.ClientID %>");

                var image = grid.getRowData(id)["item"];                
                //$('[id*="img1"]')[0].src = image;
                //$('[id*="anchor1"]')[0].href = image;
                debugger;
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/ShowImage",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    //data: "{ 'objectId':'" + grid.getRowData(id)["objectId"] + "', 'image':'" + grid.getRowData(id)["item"] + "'}",
                    data:"{}",
                    error: function (jqXHR, textStatus, errorThrown) { debugger; }
                }).done(function () {
                    
                    alert("Data Shown!");
                });
            
        }
        function getAudioData(id) {
            debugger;
                var grid = jQuery("#<%= JQGrid2.ClientID %>");
                var stream = "~/App_Data/recording1597205431.3gpp";
                var type = grid.getRowData(id)["type"];

                debugger;
                var audio = $("#audio1");
                audio.attr("src", stream).attr("type", type);
                /****************/
                audio[0].load();
                audio[0].play();
           
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
		<p></p>
		<p></p>
	</div>
</div>

</div><!-- End demo -->


</asp:Content>
