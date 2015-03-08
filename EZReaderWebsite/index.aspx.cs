using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.IO;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String filepath = Server.MapPath("SamplePDFs/");
        string[] fileEntries = Directory.GetFiles(filepath);
        Console.Write(fileEntries);
        //Response.Write()
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       /* if (this.FileUpload1.HasFile)
        {
            reader = (PdfReader)Session["document"];
            if (reader != null)
                reader.Close();
            string fileName = Server.MapPath(FileUpload1.FileName);
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            FileUpload1.SaveAs(fileName);

            string text = ExtractTextFromPdf(fileName);
            reader = new PdfReader(fileName);
            //Session["file"] = fileName;
            Session["document"] = reader;
            Session["noOfPages"] = reader.NumberOfPages.ToString();
            SetContent();
            result.Style.Add("visibility", "visible");
            result.Style.Add("overflow", "scroll");
            pnlShowPage.Visible = true;
            //reader.Close();
        }*/
    }
}