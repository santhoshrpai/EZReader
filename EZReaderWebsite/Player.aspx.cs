using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Media;

public partial class Player : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = Request.QueryString["url"];
        if (url != null)
        {
            SoundPlayer playthewavfile = new SoundPlayer(url);
            playthewavfile.Play();
            Response.Write(true);
        }
    }
}