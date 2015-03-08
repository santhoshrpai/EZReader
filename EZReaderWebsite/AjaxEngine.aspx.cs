using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

public partial class AjaxEngine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string lookupWord = Request.QueryString["word"];
        DictionaryHelper helper = new DictionaryHelper();
        string arg2 = helper.apiResponseUsage(lookupWord);
        string arg1 = helper.apiResponseDictionary(lookupWord);
        DictionaryModel model = helper.parseDictionaryResult(arg1, arg2,lookupWord);
        DataLayer.AddKeyword(lookupWord, model.Meaning, Convert.ToInt32(Session["UserID"].ToString()), Server.MapPath("\\EZReader.accdb"));
        var stringwriter = new System.IO.StringWriter();
        var serializer = new XmlSerializer(typeof(DictionaryModel));
        serializer.Serialize(stringwriter, model);
        Response.Write(stringwriter.ToString());
    }
}