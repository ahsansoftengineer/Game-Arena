<%@ Page Title="" Language="C#" MasterPageFile="~/GameArena.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Game_Areana.Category" %>

<%@ MasterType VirtualPath="~/GameArena.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphSearchPaging" runat="server">
  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12 col-md-8 col-lg-8 pt-2 pb-2 ">
          <nav aria-label="Page navigation" class="float-left">
            <ul class="pagination">
              <li id="Previous" runat="server" class="page-item">
                <asp:LinkButton class="page-link btn-danger" aria-label="Previous" ID="lbPrevious" runat="server" CommandArgument="1" OnCommand="lbPreviousNext_Command">
                      <span aria-hidden="true">&laquo;</span>
                      <span class="sr-only">Previous</span>
                </asp:LinkButton>
              </li>
              <asp:Repeater ID="rptrPaging" OnItemCommand="rptrPaging_ItemCommand" OnItemDataBound="rptrPaging_ItemDataBound" runat="server">
                <ItemTemplate>
                  <li class="page-item" id="li_paging" runat="server">
                    <asp:LinkButton ID="lbPageNo" Style="display: block" OnClientClick="myfunction(this)" CssClass="page-link" runat="server"></asp:LinkButton>
                  </li>
                </ItemTemplate>
              </asp:Repeater>
              <li id="Next" runat="server" class="page-item disabled">
                <asp:LinkButton class="page-link btn-danger" aria-label="Next" ID="lbNext" runat="server" CommandArgument="1" OnCommand="lbPreviousNext_Command">
                      <span aria-hidden="true">&raquo;</span>
                      <span class="sr-only">Next</span>
                </asp:LinkButton>
              </li>
            </ul>
          </nav>
        </div>
        <div class="col-sm-12 col-md-4 col-lg-4 mt-2 ">
          <div class="input-group ">
            <asp:TextBox ID="txtSearch" CssClass="form-control" placeholder="Search" runat="server"></asp:TextBox>
            <div class="input-group-append">
              <asp:Button ID="btnSearch" CssClass="btn btn-info" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </div>
          </div>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <div class="row mb-4">
        <div class="col-12">
          <h3 class="pb-5 position-static">
            <asp:Label ID="litSearchResult" Style="text-shadow: 2px 2px 1px black !important;" CssClass="text-warning position-absolute" runat="server"></asp:Label>
          </h3>
          <div class="row mb-5">
            <asp:Repeater ID="rptrCategory" runat="server" OnItemDataBound="rptrCategory_ItemDataBound">
              <ItemTemplate>
                <div class="col-12 mb-3">
                  <div class="row">
                    <div class="col-4 categoryImage">
                      <asp:ImageButton class="img-thumbnail float-left image" ID="ImgSmallImage" runat="server" />
                    </div>
                    <div class="col-8 pl-0">
                      <div class="row">
                        <div class="col-12 pt-2 pb-2">
                          <h4>
                            <asp:LinkButton ID="lbGameName" Style="text-shadow: 0px 0px 3px black !important;" runat="server"></asp:LinkButton>
                          </h4>
                        </div>
                        <div class="col-12">
                          <h6 class="text-danger">
                            <asp:Literal ID="litUploadDate" runat="server"></asp:Literal>
                            <asp:Repeater ID="rptrType" OnItemDataBound="rptrType_ItemDataBound" runat="server">
                              <ItemTemplate>
                                <asp:LinkButton ID="lbType" target="blank" OnClick="lbType_Click" CssClass="text-success" runat="server"></asp:LinkButton>
                              </ItemTemplate>
                            </asp:Repeater>
                          </h6>
                        </div>
                        <div class="col-12">
                          <p class="text-justify text-warning">
                            <asp:Literal ID="litPrimaryComment" runat="server"></asp:Literal>
                          </p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </ItemTemplate>
            </asp:Repeater>
          </div>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
