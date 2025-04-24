<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register TagPrefix="ft" TagName="Footer" Src="~/includes/footer.ascx" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <!-- set the viewport width and initial-scale on mobile devices -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
    <!-- set the encoding of your site -->
    <meta charset="utf-8">
    <title>MultiTracks.com</title>
    <!-- include the site stylesheet -->
    <link media="all" rel="stylesheet" href="~/PageToSync/css/index.css">
</head>
<body class="premium standard u-fix-fancybox-iframe">
    <form>
        <asp:Panel ID="ErrorPanel" runat="server">
            <div class="u-container error-message">
                <asp:Literal ID="ErrorMessageLiteral" runat="server"></asp:Literal>
            </div>
        </asp:Panel>

        <div class="u-container">
            <main class="discovery--section">
                <div class="discovery--space-saver">
                    <section class="standard--holder">
                        <div class="discovery--section--header">
                            <h2>Artists</h2>
                        </div>
                        <!-- /.discovery-select -->
                        <div class="discovery--grid-holder">
                            <div class="ly-grid ly-grid-cranberries">
                                <asp:Repeater ID="ArtistsRepeater" runat="server">
                                    <ItemTemplate>
                                        <div class="media-item">
                                            <a class="media-item--img--link" href="/PageToSync/artist-details.aspx?artistId=<%# Eval("artistID") %>">
                                                <img class="media-item--img" alt='<%# Eval("title") %>' src='<%# Eval("imageUrl") %>' />
                                            </a>
                                            <a class="media-item--title" href="/PageToSync/artist-details.aspx?artistId=<%# Eval("artistID") %>">
                                                <%# Eval("title") %></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <!-- /.media-item -->
                            </div>
                            <!-- /.grid -->
                        </div>
                        <!-- /.discovery-grid-holder -->
                    </section>
                    <!-- /.albums-section -->
                </div>
            </main>
            <!-- /.discovery-section -->
        </div>
        <!-- /.standard-container -->
        <ft:Footer runat="server" ID="footer" />
        <a class="accessibility" href="#wrapper" tabindex="20">Back to top</a>
    </form>
</body>
</html>
