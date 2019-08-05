<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Game_Areana.Admin.Admin2" %>

<%@ Register Src="~/Admin/AdminNavigation.ascx" TagPrefix="uc1" TagName="AdminNavigation" %>


<!DOCTYPE html>
<html>
<head runat="server">
  <title>Admin Game Arena</title>
  <link href="../CSS/bootstrap.min.css" rel="stylesheet" />
  <link href="../CSS/Custome.css" rel="stylesheet" />
</head>
<body class="container-fluid">
  <form id="form1" runat="server">
    <div class="row">
      <div class="col-12" style="background-color: darkslategray">
        <uc1:AdminNavigation runat="server" id="AdminNavigation" />
        <div class="row">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <%-- Game Info --%>
          <asp:UpdatePanel ID="upGameInfo" class="col-12 alert-primary pt-3" runat="server">
            <ContentTemplate>
              <div class="row">
                <div class="col-12">
                  <h5 id="GameInfos">Game Info</h5>
                </div>
              </div>
              <div class="row mt-2">
                <div class=" col-12">
                  <div class="btn-group-toggle btn-group pb-3" data-toggle="buttons" style="overflow-x: scroll; width: 100%;">
                    <asp:Repeater ID="rptrPages" runat="server" OnItemDataBound="rptrNaviation_ItemDataBound">
                      <ItemTemplate>
                        <asp:CheckBox ID="ckbPages" Width="100%" runat="server"></asp:CheckBox>
                      </ItemTemplate>
                    </asp:Repeater>
                  </div>
                </div>
              </div>
              <div class="row mt-3">
                <div class="col-12">
                  <div class="row">
                    <div class="col-lg-4 col-md-5 col-sm-12">
                      <div class="row">
                        <div class="col-12 pb-2">
                          <div class="input-group ">
                            <div class="input-group-prepend">
                              <span class="input-group-text">Game ID </span>
                            </div>
                            <asp:TextBox ID="txtGameID" CssClass="form-control" placeholder="Search" runat="server"></asp:TextBox>
                            <div class="input-group-append">
                              <asp:Button ID="btnGameID" CssClass="btn btn-info" runat="server" Text="Search" OnClick="btnGameID_Click" />
                            </div>
                          </div>
                        </div>
                        <div class="col-12 pb-2">
                          <div class="input-group ">
                            <div class="input-group-prepend">
                              <span class="input-group-text">F_Name </span>
                            </div>
                            <asp:TextBox ID="txtGameFullName" CssClass="form-control" placeholder="King of Fighter 2019" runat="server"></asp:TextBox>
                          </div>
                        </div>
                        <div class="col-12 pb-2">
                          <div class="input-group ">
                            <div class="input-group-prepend">
                              <span class="input-group-text">S_Name </span>
                            </div>
                            <asp:TextBox ID="txtGameShortName" CssClass="form-control" placeholder="KOF 19" runat="server"></asp:TextBox>
                          </div>
                        </div>
                        <div class="col-12 pb-2">
                          <div class="input-group ">
                            <div class="input-group-prepend">
                              <span class="input-group-text">Release Date</span>
                            </div>
                            <input id="dateRelease" runat="server" type="Date" class="form-control " />
                          </div>
                        </div>
                        <div class="col-12 pb-2">
                          <div class="input-group ">
                            <div class="input-group-prepend">
                              <span class="input-group-text">Upload Date</span>
                            </div>
                            <input id="dateUploaded" disabled value='<%# Eval("System.DateTime.Now()") %>' runat="server" type="Date" class="form-control " />
                          </div>
                        </div>
                        <div class="col-12 pb-2">
                          <div class="input-group ">
                            <div class="input-group-prepend">
                              <span class="input-group-text">Company</span>
                            </div>
                            <asp:TextBox ID="txtGameCompany" CssClass="form-control" placeholder="Wali Developers" runat="server"></asp:TextBox>
                          </div>
                        </div>
                        <div class="col-12 pb-2">
                          <div class="input-group ">
                            <div class="input-group-prepend">
                              <span class="input-group-text">Min Spc ID</span>
                            </div>
                            <asp:TextBox ID="txtGameMinSpecID" CssClass="form-control" placeholder="1,2,3,4.." runat="server"></asp:TextBox>
                          </div>
                        </div>
                        <div class="col-12 pb-2">
                          <div class="input-group ">
                            <div class="input-group-prepend">
                              <span class="input-group-text">Rec Spc ID</span>
                            </div>
                            <asp:TextBox ID="txtGameRecSpecID" CssClass="form-control" placeholder="5,6,7,8.." runat="server"></asp:TextBox>
                          </div>
                        </div>
                      </div>
                    </div>
                    <div class="col-lg-8 col-md-7 col-sm-12">
                      <div class="row">
                        <div class="col-12 pb-2">
                          <div class="input-group ">
                            <div class="input-group-prepend">
                              <span class="input-group-text">Primary</span>
                            </div>
                            <asp:TextBox ID="txtGamePrimaryComment" Rows="3" CssClass="form-control" placeholder="Primary Comment will be displayed with" runat="server" TextMode="MultiLine"></asp:TextBox>
                          </div>
                        </div>
                        <div class="col-12 pb-2">
                          <div class="input-group">
                            <div class="input-group-prepend">
                              <span class="input-group-text">Warning</span>
                            </div>
                            <asp:TextBox ID="txtGameWarning" Rows="3" CssClass="form-control" placeholder="Warning Messages Regarding Game" runat="server" TextMode="MultiLine"></asp:TextBox>
                          </div>
                        </div>
                        <div class="col-12 pb-2">
                          <div class="input-group">
                            <div class="input-group-prepend">
                              <span class="input-group-text">Comment 1</span>
                            </div>
                            <asp:TextBox ID="txtGameComment1" Rows="3" CssClass="form-control" placeholder="Developers Comment 1" runat="server" TextMode="MultiLine"></asp:TextBox>
                          </div>
                        </div>
                        <div class="col-12 pb-2">
                          <div class="input-group">
                            <div class="input-group-prepend">
                              <span class="input-group-text">Comment 2</span>
                            </div>
                            <asp:TextBox ID="txtGameComment2" Rows="3" CssClass="form-control" placeholder="Developers Comment 2" runat="server" TextMode="MultiLine"></asp:TextBox>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="row mt-3">
                <div class="col-12 pb-2">
                  <div class="input-group">
                    <div class="btn-group">
                      <asp:Button ID="btnGameInfoInsert" CssClass="btn btn-primary" runat="server" Text="Insert" OnClick="btnGameInfoInsert_Click" />
                      <asp:Button ID="btnGameInfoUpdate" CssClass="btn btn-success" runat="server" Text="Update" OnClick="btnGameInfoUpdate_Click" />
                      <asp:Button ID="btnGameInfoDelete" CssClass="btn btn-danger" runat="server" Text="Delete" OnClick="btnGameInfoDelete_Click" />
                    </div>
                  </div>
                  <div id="GameInfoMessage" runat="server" class="alert alert-danger alert-dismissible fade mt-3 position-absolute" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                    <strong>Message</strong>
                    <asp:Label ID="lblGameInfoMessage" ForeColor="Red" runat="server" Text="Message Game Info"></asp:Label>
                  </div>
                </div>
              </div>
            </ContentTemplate>
          </asp:UpdatePanel>
          <%-- Game Images --%>
          <asp:UpdatePanel ID="upGameImages" runat="server">
            <ContentTemplate>
              <div class="col-12 mt-4 pt-3 alert-success">
                <div class="row">
                  <div class="col-12 pb-2">
                    <h5 id="GameImages">Game Images</h5>
                  </div>
                  <div class="col-12 pb-2 ">
                    <div class="row">
                      <div class="col-lg-4 col-md-6 col-sm-12 pb-5">
                        <asp:Image ID="Image1" CssClass="img-thumbnail col-12 mb-2 bg-transparent" Height="200px" ImageUrl="~/Images/1.png" runat="server" />
                        <asp:FileUpload ID="fu_Game_Images_1" CssClass="btn btn-light btn-sm w-100" runat="server" />
                      </div>
                      <div class="col-lg-4 col-md-6 col-sm-12 pb-5">
                        <asp:Image ID="Image2" CssClass="img-thumbnail col-12 mb-2 bg-transparent" Height="200px" ImageUrl="~/Images/2.png" runat="server" />
                        <asp:FileUpload ID="fu_Game_Images_2" CssClass="btn btn-light btn-sm w-100" runat="server" />
                      </div>
                      <div class="col-lg-4 col-md-6 col-sm-12 pb-5">
                        <asp:Image ID="Image3" CssClass="img-thumbnail col-12 mb-2 bg-transparent" Height="200px" ImageUrl="~/Images/3.png" runat="server" />
                        <asp:FileUpload ID="fu_Game_Images_3" CssClass="btn btn-light btn-sm w-100" runat="server" />
                      </div>
                      <div class="col-lg-4 col-md-6 col-sm-12 pb-5">
                        <asp:Image ID="Image4" CssClass="img-thumbnail col-12 mb-2 bg-transparent" Height="200px" ImageUrl="~/Images/4.png" runat="server" />
                        <asp:FileUpload ID="fu_Game_Images_4" CssClass="btn btn-light btn-sm w-100" runat="server" />
                      </div>
                      <div class="col-lg-4 col-md-6 col-sm-12 pb-5">
                        <asp:Image ID="Image5" CssClass="img-thumbnail col-12 mb-2 bg-transparent" Height="200px" ImageUrl="~/Images/5.png" runat="server" />
                        <asp:FileUpload ID="fu_Game_Images_5" CssClass="btn btn-light btn-sm w-100" runat="server" />
                      </div>
                    </div>
                  </div>
                  <div class="col-12 pb-2">
                    <div class="input-group">
                      <div class="btn-group">
                        <asp:Button ID="btnImgUpdate" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnImgUpdate_Click" />
                      </div>
                    </div>
                    <div id="ImagesMessage" runat="server" class="alert alert-danger alert-dismissible fade mt-3 position-absolute" role="alert">
                      <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                      </button>
                      <strong>Message</strong>
                      <asp:Label ID="lblImagesMessage" ForeColor="Red" runat="server" Text="Message Game Info"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
            </ContentTemplate>
          </asp:UpdatePanel>
          <%--Tech Info--%>
          <asp:UpdatePanel ID="upTechInfo" class="col-sm-12 col-md-6 col-lg-6 mt-4 pt-3 alert-warning" runat="server">
            <ContentTemplate>
              <div class="row">
                <div class="col-12 pb-2">
                  <h5 id="TechSpecs">Technical Specification</h5>
                </div>
                <div class="col-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Version </span>
                    </div>
                    <asp:TextBox ID="txtTSGameVersion" CssClass="form-control" placeholder=" Initial Release" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Interface</span>
                    </div>
                    <asp:TextBox ID="txtTSInterfaceLanguage" CssClass="form-control" placeholder="English" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Audio Lang</span>
                    </div>
                    <asp:TextBox ID="txtTSAudioLanguage" CssClass="form-control" placeholder="English" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Uploader</span>
                    </div>
                    <asp:TextBox ID="txtTSUploader" CssClass="form-control" placeholder="Plaza" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <asp:FileUpload ID="fuGameFileName" CssClass="btn btn-light btn-sm w-100" runat="server" />
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Game Size</span>
                    </div>
                    <asp:TextBox ID="txtTSGameSize" Enabled="false" CssClass="form-control" placeholder="6.6 GB" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group">
                    <div class="input-group-prepend">
                      <span class="input-group-text">MDSSUM</span>
                    </div>
                    <asp:TextBox ID="txtTSMDSSUM" CssClass="form-control" placeholder="fc188a8f5498cb5738678bd6963f190a" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group">
                    <div class="btn-group">
                      <asp:Button ID="btnTechSpcUpdate" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnTechSpcUpdate_Click" />
                    </div>
                  </div>
                  <div id="TechSpcMessage" runat="server" class="alert alert-danger alert-dismissible fade mt-3 position-absolute" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                    <strong>Message</strong>
                    <asp:Label ID="lblTechSpcMessage" ForeColor="Red" runat="server" Text="Message Game Info"></asp:Label>
                  </div>
                </div>
              </div>
            </ContentTemplate>
          </asp:UpdatePanel>
          <%-- Min Rec Spec --%>
          <asp:UpdatePanel ID="upMinRecSpec" class="col-sm-12 col-md-6 col-lg-6 alert-info mt-4 pt-3" runat="server">
            <ContentTemplate>
              <div class="row">
                <div class="col-12 pb-2">
                  <h5 id="MinRecSpecs">Min / Rec Specification</h5>
                </div>
                <div class="col-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Spec ID</span>
                    </div>
                    <asp:TextBox ID="txtSpcID" CssClass="form-control" placeholder="Search" runat="server"></asp:TextBox>
                    <div class="input-group-append">
                      <asp:Button ID="btnSpecSearch" OnClick="btnSpecSearch_Click" CssClass="btn btn-info" runat="server" Text="Search" />
                    </div>
                  </div>
                </div>
                <div class="col-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">OS </span>
                    </div>
                    <asp:TextBox ID="txtMinRecSpcOS" CssClass="form-control" placeholder="Windows 7, Vista, 8, 8.1, 10...  " runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Processor</span>
                    </div>
                    <asp:TextBox ID="txtMinRecSpcProcessor" CssClass="form-control" placeholder="Intel Core i7, i5, i3..." runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Memory</span>
                    </div>
                    <asp:TextBox ID="txtMinRecSpcMemory" CssClass="form-control" placeholder="4 GB, 2 GB, 1 GB..." runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Graphics </span>
                    </div>
                    <asp:TextBox ID="txtMinRecSpcGraphics" CssClass="form-control" placeholder="Geforce GTX 950" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">DirectX </span>
                    </div>
                    <asp:TextBox ID="txtMinRecSpcDirectX" CssClass="form-control" placeholder="DirectX 10" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Storage </span>
                    </div>
                    <asp:TextBox ID="txtMinRecSpcStorage" CssClass="form-control" placeholder="10 GB, 20 GB, 40 GB..." runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group ">
                    <div class="input-group-prepend">
                      <span class="input-group-text">Sound</span>
                    </div>
                    <asp:TextBox ID="txtMinRecSpcSoundCard" CssClass="form-control" placeholder="Realtek High Definition Audio" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-sm-12 pb-2">
                  <div class="input-group">
                    <div class="btn-group">
                      <asp:Button ID="btnSpcInsert" OnClientClick="return validateControl()" CssClass="btn btn-primary" runat="server" Text="Insert" OnClick="btnSpcInsert_Click" />
                      <asp:Button ID="btnSpcUpdate" CssClass="btn btn-success" runat="server" Text="Update" OnClick="btnSpcUpdate_Click" />
                      <asp:Button ID="btnSpcDelete" CssClass="btn btn-danger" runat="server" Text="Delete" OnClick="btnSpcDelete_Click" />
                    </div>
                  </div>
                  <div id="SpcMessage" runat="server" class="alert alert-danger alert-dismissible fade mt-3 position-absolute" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                    <strong>Message</strong>
                    <asp:Label ID="lblSpcMessage" ForeColor="Red" runat="server" Text="Message Game Info"></asp:Label>
                  </div>
                </div>
              </div>
            </ContentTemplate>
          </asp:UpdatePanel>
        </div>
      </div>
    </div>
  </form>
</body>
<script src="../JS/jquery-3.3.1.min.js"></script>
<script src="../JS/bootstrap.min.js"></script>
</html>
