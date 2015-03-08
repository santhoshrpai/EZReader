<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="BootstrapFolder/Scripts/jquery-1.9.1.js"></script>
    <script src="BootstrapFolder/Scripts/bootstrap.js"></script>
    <link href="BootstrapFolder/Bootstrap/bootstrap.css" rel="stylesheet" />    
<head runat="server">
    <title>EZReader</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

                <div id="myCarousel" class="carousel slide" data-ride="carousel" >
                  <!-- Indicators -->
                  <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                  </ol>

                  <!-- Wrapper for slides -->




                    	
                  <!-- Wrapper for slides -->
                  <div class="carousel-inner" role="listbox">
                     <div class="item active">
                      <img src="Image/slide2.jpg" alt="Book">
                      <div class="carousel-caption" style="margin-left:-850px">
                        <h1>EZRead</h1>
                        <p>The atmosphere in Chania has a touch of Florence and Venice.</p>
                      </div>
                    </div>

                    <div class="item">
                      <img src="Image/slide1.jpg" alt="Book">
                      <div class="carousel-caption" style="margin-left:-950px">
                        <h1 >EZRead</h1>
                        <p>Read With Ease</p>
                      </div>
                    </div>  
                      </div>








                  <!-- Left and right controls -->
                  <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                  </a>
                  <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                  </a>
                </div>
               <div style="height:150px" >
                    <div style="float:left; width:45%;">
                        <div class="alert alert-info" role="alert">Hi Pravin</div>
                                <h3>You have 5 Books in your shelf </h3>
                        </div>



                    <div style="float:left; width:25%;">
                          <div class="alert alert-info" role="alert">Upload New Book</div>
                          <div class="panel-body">
                           <div> 
                               <asp:FileUpload ID="FileUpload2" runat="server" /> 
                               <asp:Button ID="Button2" runat="server" Text="Upload" class="btn btn-primary" style="margin-left: 270px; margin-top:-50px;" OnClick="Button1_Click" /> 
                               </div>
                          </div>
                        </div>
                     


                    <div style="float:right; width:30%;">
                          <div class="alert alert-info" role="alert">Paste the PDF Url</div>
                          <div class="panel-body">
                           <div> 
                             <textbox id="URLDownload"></textbox>  
                             </div>
                          </div>
                        </div>
                     </div>

             
            </div>




                      <div class="panel panel-primary">
              <div class="panel-heading" style="text-align:center">Bookshelf</div>
                   <div class="jumbotron">                
                    <div class="panel-body">
                 <div class="row">
                 <div class="col-xs-6 col-md-3">
                 <a href="Default.aspx" class="thumbnail" style="background-color:#eee ; max-height:250px">
                    <img src="Image/OliverTwist.png" width="120" height="200" class="img-rounded" />
                   <h3>Oliver Twist</h3>
                  </a>
                 </div>    
                 

                 <div class="col-xs-6 col-md-3">
                 <a href="Default.aspx" class="thumbnail" style="background-color:#eee ; max-height:250px">
                    <img src="Image/30597.JPG" width="120" height="200" class="img-rounded" />
                   <h3 style="text-align:center">Victor Hugo</h3>
                  </a>
                 </div>    

                 <div class="col-xs-6 col-md-3">
                 <a href="Default.aspx" class="thumbnail" style="background-color:#eee ; max-height:250px">
                    <img src="Image/AStudyInScarlet.jpg" width="120" height="200" class="img-rounded" />
                   <h3 style="text-align:center">A Study In Scarlet</h3>
                  </a>
                 </div>    

                  <div class="col-xs-6 col-md-3">
                 <a href="Default.aspx" class="thumbnail" style="background-color:#eee ; max-height:250px">
                    <img src="Image/tale-of-two-cities-book-cover.jpg" width="120" height="200" class="img-rounded" />
                   <h3 style="text-align:center">A Tale of Two Citie</h3>
                  </a>
                 </div>    
                   
                      </div>

                        <div class="row">
                             <div class="col-xs-6 col-md-3">
                     <a href="Default.aspx" class="thumbnail" style="background-color:#eee ; max-height:250px">
                    <img src="Image/around-80days.jpg" width="120" height="200" class="img-rounded" />
                   <h3 style="text-align:center">Around the world in 80 days</h3>
                         </a>  
                 </div>
                  </div>
    
                
                            
             </div>
             </div>  
             </div>








                
                



    </div>
    </form>
</body>
</html>
