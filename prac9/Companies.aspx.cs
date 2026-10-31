using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace P9_PlacementDashboard
{
    public partial class Companies : System.Web.UI.Page
    {
        //connection string
        string cs = ConfigurationManager.ConnectionStrings["PlacementDbConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompanies();
                LoadPlacements();
            }
        }

        private void LoadCompanies()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Placements";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rptCompanies.DataSource = dt;
                rptCompanies.DataBind();
            }
        }

        private void LoadPlacements()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Placements";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dlPlacements.DataSource = dt;
                dlPlacements.DataBind();
            }
        }
    }
}
