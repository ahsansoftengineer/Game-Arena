<%@ Page Title="" Language="C#" MasterPageFile="~/GameArena.Master" AutoEventWireup="true" CodeBehind="Description.aspx.cs" Inherits="Game_Areana.Description" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
  <div class="row pt-2">
    <div class="col-12">
      <h2 class="text-danger mt-1 mb-4">
        <asp:Literal ID="litGameName1" runat="server"></asp:Literal>&nbsp;Free Download</h2>
      <h5 class="mt-2 mb-2 text-info">About Game</h5>
      <p class="mt-3 text-success">
        <asp:Literal ID="litPrimaryComment" runat="server"></asp:Literal>
      </p>
      <h5 class="mt-2 mb-2 text-primary">PC Game
        <asp:Literal ID="litGameYear" runat="server"></asp:Literal>
        &nbsp;
        <asp:Literal ID="litGameName2" runat="server"></asp:Literal>&nbsp;
        Over View </h5>
      <div class="row align-content-center pt-4 pb-4">
        <div class="col-md-10 imgLargeBox">
          <asp:Image class="img-thumbnail image" ID="ImgCurrentGame1" runat="server" />
        </div>
      </div>
      <p class="mt-1 text-info">The idea and the feelings about the game is discribed by the developers</p>
      <div class="alert alert-secondary alert-dismissible fade show" role="alert">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
          <span aria-hidden="true">&times;</span>
          <span class="sr-only">Close</span>
        </button>
        <strong>Developer Comment 1 : </strong>
        <asp:Literal ID="litDevComment1" runat="server"></asp:Literal>.
      </div>
      <div class="alert alert-info alert-dismissible fade show" role="alert">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
          <span aria-hidden="true">&times;</span>
          <span class="sr-only">Close</span>
        </button>
        <strong>Developer Comment 2 : </strong>
        <asp:Literal ID="litDevComment2" runat="server"></asp:Literal>
      </div>
      <div class="alert alert-danger alert-dismissible fade show" role="alert">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
          <span aria-hidden="true">&times;</span>
          <span class="sr-only">Close</span>
        </button>
        <strong>Warning! : </strong>
        <asp:Literal ID="litWarning" runat="server"></asp:Literal>
      </div>
      <div class="row pt-4 pb-4">
        <div class="col-md-10 imgLargeBox">
          <asp:Image class="img-thumbnail image" ID="ImgCurrentGame2" runat="server" />
        </div>
      </div>
      <div class="alert alert-primary">
        <h5 class="mt-2 mb-3">Technical Specificaiton of
    <asp:Literal ID="litGameName3" runat="server"></asp:Literal></h5>
        <ul>
          <li>Game Version : <i>
            <asp:Literal ID="litTechGameVersion" runat="server"></asp:Literal></i></li>
          <li>Interface Language : <i>
            <asp:Literal ID="litTechInterfaceLanguage" runat="server"></asp:Literal></i></li>
          <li>Audio Language : <i>
            <asp:Literal ID="litTechAudioLanguage" runat="server"></asp:Literal></i></li>
          <li>Uploader / Re packer Group : <i>
            <asp:Literal ID="litTechUploader" runat="server"></asp:Literal></i></li>
          <li>Game File Name : <i>
            <asp:Literal ID="litTechGameFileName" runat="server"></asp:Literal></i></li>
          <li>Game Download Size : <i>
            <asp:Literal ID="litTechGameSize" runat="server"></asp:Literal></i></li>
          <li>MBSSUM : <i>
            <asp:Literal ID="litTechMDSSUM" runat="server"></asp:Literal></i></li>
        </ul>
      </div>

      <div class="row align-content-center pt-4 pb-4">
        <div class="col-md-10 imgLargeBox" style="height: 250px">
          <asp:Image class="img-thumbnail image" ID="imgCurrentGame3" runat="server" />
        </div>
      </div>
      <h5 class="mt-2 mb-2 text-primary">System Requirement of
    <asp:Literal ID="litGameName4" runat="server"></asp:Literal></h5>
      <p class="text-info">
        Before you start <i>
          <asp:Literal ID="litGameName5" runat="server"></asp:Literal></i> Free Download make sure your PC meet the following Requirement
      </p>
      <div class="alert alert-warning">
        <h5 class="mt-2 mb-3">Minimum Specification</h5>
        <ul>
          <li>OS : <i>
            <asp:Literal ID="litMinOS" runat="server"></asp:Literal></i></li>
          <li>Processor : <i>
            <asp:Literal ID="litMinProcessor" runat="server"></asp:Literal></i></li>
          <li>Memory : <i>
            <asp:Literal ID="litMinMemory" runat="server"></asp:Literal></i></li>
          <li>Graphics : <i>
            <asp:Literal ID="litMinGraphics" runat="server"></asp:Literal></i></li>
          <li>DirectX : <i>
            <asp:Literal ID="litMinDirectX" runat="server"></asp:Literal></i></li>
          <li>Storage : <i>
            <asp:Literal ID="litMinStorage" runat="server"></asp:Literal></i></li>
          <li>Sound Card : <i>
            <asp:Literal ID="litMinSoundCard" runat="server"></asp:Literal></i></li>
        </ul>
      </div>
      <div class="alert alert-success">
        <h5 class="mt-2 mb-3">Recomended Specification</h5>
        <ul>
          <li>OS : <i>
            <asp:Literal ID="litRecOS" runat="server"></asp:Literal>
          </i></li>
          <li>Processor : <i>
            <asp:Literal ID="litRecProcessor" runat="server"></asp:Literal></i></li>
          <li>Memory : <i>
            <asp:Literal ID="litRecMemory" runat="server"></asp:Literal></i></li>
          <li>Graphics : <i>
            <asp:Literal ID="litRecGraphics" runat="server"></asp:Literal></i></li>
          <li>DirectX : <i>
            <asp:Literal ID="litRecDirectX" runat="server"></asp:Literal></i></li>
          <li>Storage : <i>
            <asp:Literal ID="litRecStorage" runat="server"></asp:Literal></i></li>
          <li>Sound Card : <i>
            <asp:Literal ID="litRecSoundCard" runat="server"></asp:Literal></i></li>
        </ul>
      </div>

      <div class="row pt-4 pb-4">
        <div class="col-md-10 imgLargeBox">
          <asp:Image class="img-thumbnail image " ID="imgCurrentGame4" runat="server" />
        </div>
      </div>
      <div class="alert alert-dark">
        <h5 class="mt-2 mb-3">
          <asp:Literal ID="litGameName6" runat="server"></asp:Literal>
        </h5>
        <p>
          Click on the below button to start <i>
            <asp:Literal ID="litGameName7" runat="server"></asp:Literal></i> Download. It is full and complete game. Just download and start playing it. We have provided direct link full setup of the game.
        </p>
      </div>
      <h4 class="text-danger text-center">Click below Button and Wait For Few Seconds On Next Page. Download Will Start Automaticall. Installation Guide Video is also on Button of Next Page.
      </h4>
      <div class="m-auto col-3 pt-4 pb-2">
        <asp:Button ID="btnDownload" CssClass="btn btn-danger btn-lg" runat="server" Text="Download" />
      </div>
    </div>
  </div>
  <div class="row pt-2">
    <div class="col-12">
      <h6 class="text-warning pt-3 pb-3">You May Also Like:</h6>
      <div class="row mt-2">
        <asp:Repeater ID="rptrRelatedLinks" runat="server" OnItemDataBound="rptrRelatedLinks_ItemDataBound">
          <ItemTemplate>
            <div class="col-lg-3 col-sm-4 mb-5 mt-1" style="text-align: center; height:120px">
              <asp:ImageButton ID="imgRelatedLink" class="img-thumbnail image" runat="server" />
              <asp:LinkButton ID="lbCategoryPage" runat="server">LinkButton</asp:LinkButton>
            </div>
          </ItemTemplate>
        </asp:Repeater>
      </div>
    </div>
  </div>
</asp:Content>
