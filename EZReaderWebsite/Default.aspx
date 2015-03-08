<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EZReader</title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="BootstrapFolder/Scripts/jquery-1.9.1.js"></script>
    <script src="BootstrapFolder/Scripts/bootstrap.js"></script>
     <link href="BootstrapFolder/Bootstrap/bootstrap.css" rel="stylesheet" />
    <script>
        $(function () {
            $("#result").bind('mouseup', function (e) {
                var selection;
                if (window.getSelection) {
                    selection = window.getSelection();
                } else if (document.selection) {
                    selection = document.selection.createRange();
                }
                var data = selection.toString();
                if(data.length>1) {
                    $.ajax({
                        type: "GET",
                        url: "AjaxEngine.aspx?word=" + data,
                        success: function (msg) {
                            var audio = $(msg).find("AudioUrl").text();
                            var sentence = $(msg).find("SentenceUsage").text();
                            var meaning = $(msg).find("Meaning").text();
                            document.getElementById("audio").style.visibility = 'visible';
                            document.getElementById("meaning").style.visibility = 'visible';
                            document.getElementById("usage").style.visibility = 'visible';

                            document.getElementById("usage").innerHTML = '<b>Use in Sentence:</b>' + sentence;
                            document.getElementById("meaning").innerHTML = '<b><label style="font-size:50px;">' + data + '</label></b><br/><b>Meaning</b>' + meaning;
                            document.getElementById("audio").textContent = audio;
                        },
                        error: function (msg) {
                            document.getElementById("audio").style.visibility = 'hidden';
                            document.getElementById("meaning").style.visibility = 'hidden';
                            document.getElementById("usage").style.visibility = 'hidden';
                        }
                    });
                }
            });
            $('#audio').bind('click', function (e) {
                var url = document.getElementById("audio").textContent;
                $.ajax({
                    type: "GET",
                    url: "Player.aspx?url=" + url,
                    success: function (msg) {
                        // alert(msg);
                    }
                });
            });
        });

        function showMeaning(text) {
            $.ajax({
                type: "GET",
                url: "AjaxEngine.aspx?word=" + text,
                success: function (msg) {
                    var audio = $(msg).find("AudioUrl").text();
                    var sentence = $(msg).find("SentenceUsage").text();
                    var meaning = $(msg).find("Meaning").text();
                    document.getElementById("audio").style.visibility = 'visible';
                    document.getElementById("meaning").style.visibility = 'visible';
                    document.getElementById("usage").style.visibility = 'visible';

                    document.getElementById("usage").innerHTML = '<b>Use in Sentence:</b>' + sentence;
                    document.getElementById("meaning").innerHTML = '<b><label style="font-size:50px;">' + text + '</label></b><br/><b>Meaning</b>' + meaning;
                    document.getElementById("audio").textContent = audio;
                },
                error: function (msg) {
                    document.getElementById("audio").style.visibility = 'hidden';
                    document.getElementById("meaning").style.visibility = 'hidden';
                    document.getElementById("usage").style.visibility = 'hidden';
                }
            });
        }

    </script>
</head>
<body style="font-family:Tahoma;text-align:center">
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
        <div style="float: left; width: 70%;">
                
                    <div class="panel panel-primary">
                    <div class="panel-heading">Oliver Twist</div>
                    <div class="jumbotron">
                                <%--<div style="height: 69px; width: 231px">    
                                <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
                                    <br />
                                <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" Visible="False" />
                                </div>--%>
                    <div class="panel-body" style="width:100%;margin-left:100px;height:100%">
                            <table style="text-align:center;width:70%;height:100%" border="0" >
                                <tr>
                                    <td >
                                        <asp:Panel runat="server" ID="Panel1" Visible="false" HorizontalAlign="Center">
                                                                                <asp:Button ID="Button2"  class="btn btn-primary" runat="server" Text="<<- First" OnClick="btnFirst_Click" /> &nbsp;
                                                                                <asp:Button ID="Button3"  class="btn btn-primary" runat="server" Text="<- Prev" OnClick="btnPrev_Click" /> &nbsp;
                                            <asp:Label ID="Label1" runat="server" Text="Showing page "></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text=" of "></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text=""></asp:Label> &nbsp;
                                            <asp:Button ID="Button4"  class="btn btn-primary" runat="server" Text="Next ->" OnClick="btnNext_Click" /> &nbsp;
                                            <asp:Button ID="Button5"  class="btn btn-primary" runat="server" Text="Last -->" OnClick="btnLast_Click" />
                                    </asp:Panel>
                                        <br />
                                    </td>
                                    </tr>
                                    <tr>
                                    <td>
                                     <!-- This div displays the content of the document -->
                                    <div id="result" runat="server" style="text-align:left;margin-left:100px;border-color:black;border-style:outset;border-width:thin;height:460px;width:70%;vertical-align:central;visibility:hidden"/>
                                    <br />
                                    <asp:Panel runat="server" ID="pnlShowPage" Visible="false" HorizontalAlign="Center">
                                                                                <asp:Button ID="btnFirst"  class="btn btn-primary" runat="server" Text="<<- First" OnClick="btnFirst_Click" /> &nbsp;
                                                                                <asp:Button ID="btnPrev"  class="btn btn-primary" runat="server" Text="<- Prev" OnClick="btnPrev_Click" /> &nbsp;
                                            <asp:Label ID="lblShow" runat="server" Text="Showing page "></asp:Label>
                                            <asp:Label ID="lblCurrentPage" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="lblOf" runat="server" Text=" of "></asp:Label>
                                            <asp:Label ID="lblTotalPages" runat="server" Text=""></asp:Label> &nbsp;
                                                                                <asp:Button ID="btnNext"  class="btn btn-primary" runat="server" Text="Next ->" OnClick="btnNext_Click" /> &nbsp;
                                                                                <asp:Button ID="btnLast"  class="btn btn-primary" runat="server" Text="Last -->" OnClick="btnLast_Click" />
                                    </asp:Panel>
    
                                    </td>
                                </tr>
                            </table>
                    </div>
                    </div>
                    </div>
                    
        </div>
        <div style="float: right; width: 30%;" >
            <div class="panel panel-primary">
            <div class="panel-heading">Dictionary</div>
            <div class="panel-body">
            </div>
                <asp:Label ID="meaning" runat="server" Text="Meaning:" style="visibility:hidden"></asp:Label>
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server">
                <asp:Image ID="audio" runat="server" ImageUrl="pronounce.png" Height="20px" Width="20px" style="cursor: pointer; visibility:hidden;"/>
                </asp:HyperLink>
                <br />
                <asp:Label ID="usage" runat="server" Text="Usage in Sentences:" style="visibility:hidden"></asp:Label>
            </div>
        </div>
    <br /><br />
        <div style="float:right; width: 30%;" >
            <div class="panel panel-primary">
            <div class="panel-heading">Memory test</div>
            <div class="panel-body">
            </div>
                <asp:Label ID="lblMemoryMessage" runat="server" Text="Hey you have come across these word(s). Do you remember the meanings? <br> " Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
                <br />                
            </div>
        </div>
    <br /><br />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

        <div style="float:right; width: 30%;" >
            <div class="panel panel-primary">
            <div class="panel-heading">Translate</div>
            <div class="panel-body">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Choose your language"></asp:Label>
                <br />
                <asp:RadioButton ID="Spanish" runat="server" Text="Spanish" Checked="True" GroupName="lang" />
                <asp:RadioButton ID="Italian" runat="server" Text="Italian" GroupName="lang" />
                <asp:RadioButton ID="French" runat="server" Text="French" GroupName="lang" />
                <br />
                <asp:Button ID="btn_Translate" runat="server" OnClick="btn_Translate_Click" Text="Translate" />
                <br />
                
                <asp:Label ID="Lblang" runat="server" Font-Size="30px" Font-Bold="True"></asp:Label>
                
            </div>
                
            </div>
        </div>
            </ContentTemplate>
            </asp:UpdatePanel>
      </form>  
</body>
</html>
