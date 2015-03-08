using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.UI;

public partial class _Default : System.Web.UI.Page
{
    //int noOfPages = 0;
    int currentPage = 1;
    string data = string.Empty;
    PdfReader reader;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //load data from pdf file.
            Session["UserID"] = "1";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.FileUpload1.HasFile)
            {
                PdfReader reader1 = (PdfReader)Session["document"];
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
                result.InnerText = "";
                //reader.Close();
            }
        }
        catch (IOException exception)
        {
            Console.WriteLine(
                "{0}: The write operation could not " +
                "be performed because the specified " +
                "part of the file is locked.",
                exception.GetType().Name);
        }
    }

    protected string ExtractTextFromPdf(string path)
    {
        PdfReader reader = new PdfReader(path);
        string txt = PdfTextExtractor.GetTextFromPage(reader, 1, new LocationTextExtractionStrategy());
        return txt;
    }

    private void SetContent()
    {
        reader = (PdfReader)Session["document"];
        data = PdfTextExtractor.GetTextFromPage(reader, currentPage, new LocationTextExtractionStrategy());
        lblTotalPages.Text = Session["noOfPages"].ToString();
        lblText.Text = "";
        lblMemoryMessage.Visible = false;

        result.InnerText = "";
        data = data.Replace("\n", "<br>");
        //string[] keywords = { "Application", "verify", "Software" };
        DictionaryModel[] output = DataLayer.GetKeywords(1, Server.MapPath("\\EZReader.accdb"));
        string[] keywords = null;

        if (output != null)
        {
            keywords = new string[output.Length];

            for (int i = 0; i < output.Length; i++)
            {
                keywords[i] = output[i].Word;
            }
        }

        lblCurrentPage.Text = currentPage.ToString();
        if (keywords != null)
        {
            bool isKeyWordPresent = false;
            foreach (string item in keywords)
            {
                if (data.ToLower().Contains(item))
                {
                    isKeyWordPresent = true;
                    break;
                }
            }
            if (isKeyWordPresent)
            {
                string[] text = data.Split(' ');
                int pos=1;
                string str = string.Empty;
                for (int i = 0; i < text.Length; i++)
                {
                    if (keywords.Contains(text[i].Replace("<br>", "").ToLower()))
                    {
                        for (int j = 0; j < output.Length; j++)
                        {
                            if (output[j].Word.Equals(text[i].Replace("<br>", "").ToLower()))
                            {
                                result.InnerHtml += " <b> " + text[i] + " </b> ";
                                lblMemoryMessage.Visible = true;
                                lblText.Text += "<a style=\"cursor:pointer\" onclick=\"showMeaning('"+output[j].Word+"')\"> <b>"+ output[j].Word + " </b> </a> <br>";
                                pos++;
                                break;
                            }
                        }
                        
                    }
                    else
                    {
                        result.InnerHtml += text[i] + " ";
                    }
                }
                //result.InnerHtml += str;

            }
            else
            {
                lblMemoryMessage.Visible = false;
                lblText.Text = "";
                result.InnerHtml = data;
            }
        }
        else
            result.InnerHtml = data;

        if (currentPage < Convert.ToInt32(Session["noOfPages"].ToString()))
            btnNext.Enabled = true;
        else
            btnNext.Enabled = false;

        if (currentPage > 1)
            btnPrev.Enabled = true;
        else
            btnPrev.Enabled = false;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblCurrentPage.Text) < Convert.ToInt32(lblTotalPages.Text))
        {
            btnNext.Enabled = true;
            currentPage = Convert.ToInt32(lblCurrentPage.Text) + 1;
            //if (currentPage == Convert.ToInt32(Session["noOfPages"].ToString()))
            //    btnNext.Enabled = false;
            //else
            //    btnNext.Enabled = true;
            SetContent();
        }

        else
        {
            btnNext.Enabled = false;
        }
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblCurrentPage.Text) >= 1)
        {
            btnPrev.Enabled = true;
            btnNext.Enabled = true;
            currentPage = Convert.ToInt32(lblCurrentPage.Text) - 1;
            //if (currentPage == 1)
            //    btnPrev.Enabled = false;
            //else
            //    btnPrev.Enabled = true;
            SetContent();
        }
        else
        {
            btnPrev.Enabled = false;
        }
    }
    protected void btnFirst_Click(object sender, EventArgs e)
    {
        currentPage = 1;
        SetContent();
        //btnPrev.Enabled = false;
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        lblTotalPages.Text = Session["noOfPages"].ToString();
        currentPage = Convert.ToInt32(Session["noOfPages"].ToString());
        SetContent();
        //btnNext.Enabled = false;
    }
}