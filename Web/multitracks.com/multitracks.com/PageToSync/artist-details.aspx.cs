using DataAccess;
using System;
using System.Data;
using System.Diagnostics;

public partial class artist_details : MultitracksPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                MainPanel.Visible = false;
                ErrorPanel.Visible = false;

                if (int.TryParse(Request.QueryString["artistId"], out int artistId))
                {
                    BindDetails(artistId);
                }
                else
                {
                    WriteError("You must supply a valid artist identifier.");
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                WriteError("We're sorry but an error occurred.");
            }            
        }
    }

    private void BindDetails(int artistId)
    {
        var sql = new SQL();
        sql.Parameters.Add("@artistID", artistId);
        DataSet dataSet = sql.ExecuteStoredProcedureDS("GetArtistDetails");

        DataTable artistTable = dataSet.Tables[0];
        DataTable albumsTable = dataSet.Tables[1];
        DataTable songsTable = dataSet.Tables[2];

        if (artistTable.RowCount() > 0)
        {
            MainPanel.Visible = true;
            BindArtist(artistTable);
            BindAlbums(albumsTable);
            BindSongs(songsTable);
        }
        else
        {
            WriteError("We couldn't find an artist by that identifier.");
        }
    }

    private void BindArtist(DataTable artistTable)
    {
        HeroImage.ImageUrl = DB.Write<string>(artistTable, "heroURL");
        HeroImage.AlternateText = DB.Write<string>(artistTable, "title");
        ArtistImage.ImageUrl = DB.Write<string>(artistTable, "imageURL");
        ArtistNameLink.Text = DB.Write<string>(artistTable, "title");
        BiographyLiteral.Text = DB.Write<string>(artistTable, "biography");
    }

    private void BindAlbums(DataTable albumsTable)
    {
        AlbumsRepeater.DataSource = albumsTable;
        AlbumsRepeater.DataBind();
    }

    private void BindSongs(DataTable songsTable)
    {
        SongsRepeater.DataSource = songsTable;
        SongsRepeater.DataBind();
    }
    private void WriteError(string errorText)
    {
        ErrorPanel.Visible = true;
        ErrorMessageLiteral.Text = errorText;
    }
}