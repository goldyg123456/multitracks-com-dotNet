using DataAccess;
using System;
using System.Data;
using System.Diagnostics;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                var sql = new SQL();
                DataTable artistsTable = sql.ExecuteStoredProcedureDT("GetAllArtists");

                if (artistsTable != null && artistsTable.Rows.Count > 0)
                {
                    ArtistsRepeater.DataSource = artistsTable;
                    ArtistsRepeater.DataBind();
                }
                else
                {
                    WriteError("We couldn't find any artists.");
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                WriteError("We're sorry but an error occurred.");
            }
        }
    }
    private void WriteError(string errorText)
    {
        ErrorPanel.Visible = true;
        ErrorMessageLiteral.Text = errorText;
    }
}