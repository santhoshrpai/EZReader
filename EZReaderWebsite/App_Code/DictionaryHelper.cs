using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DictionaryHelper
{
    private string apiKeyDictionary;
    private string apiKeyUsage;
    public DictionaryHelper()
	{
		//
		// TODO: Add constructor logic here
		//
        apiKeyDictionary = "2c99030d-2409-499e-bcf6-ce24fb40ec3a";
        apiKeyUsage = "a2a73e7b926c924fad7001ca3111acd55af2ffabf50eb4ae5";
	}
    public string apiResponseDictionary(string lookUpWord)
    {
        String baseUrl = "http://www.dictionaryapi.com/api/v1/references/collegiate/xml/";
        String fullUrl = baseUrl + lookUpWord + "?key=" + apiKeyDictionary;

        WebClient client = new WebClient();
        byte[] data = client.DownloadData(fullUrl);
        string text = System.Text.Encoding.Default.GetString(data);
      
        return text;
    }
    public string apiResponseUsage(string lookUpWord)
    {
        String baseUrl = "http://api.wordnik.com/v4/word.xml/";
        String fullUrl = baseUrl + lookUpWord + "/topExample?useCanonical=false&api_key=" + apiKeyUsage;

        WebClient client = new WebClient();
        byte[] data = client.DownloadData(fullUrl);
        string text = System.Text.Encoding.Default.GetString(data);

        return text;
    }

    
    public DictionaryModel parseDictionaryResult(string xml,string usageXml)
    {
        try
        {
            DictionaryModel model = new DictionaryModel();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            string item1 = xmlDoc.SelectSingleNode("//entry/def/dt").InnerText;
            model.Meaning = item1;
            XmlNodeList parentNode2 = xmlDoc.GetElementsByTagName("entry/sound");
            string item2 = xmlDoc.SelectSingleNode("//entry/sound/wav").InnerText;
            model.AudioUrl = "http://media.merriam-webster.com/soundc11/h/" + item2;
            

            //Code for returning usage in a sentence.

            XmlDocument xmlUsageDoc = new XmlDocument();
            xmlUsageDoc.LoadXml(usageXml);
            XmlNode xmlNode;
            xmlNode = xmlUsageDoc.SelectSingleNode("//text");

            String usage = xmlNode.InnerText.Trim();
            model.SentenceUsage = usage;
            return model;
        }
        catch(Exception e)
        {
            return null;
        }
        
    }

    public string translationResponse(string lookUpWord, string toLang)
    {
        String baseUrl = "http://api.mymemory.translated.net/get?q=";
        String fullUrl = baseUrl + lookUpWord + "&langpair=en|" +toLang+"&of=tmx";

        WebClient client = new WebClient();
        byte[] data = client.DownloadData(fullUrl);
        string text = System.Text.Encoding.Default.GetString(data);

        

        const string removeString = "<!DOCTYPE tmx SYSTEM \"tmx11.dtd\">";
        int index = text.IndexOf(removeString);
        int length = removeString.Length;
        string startOfString = text.Substring(0, index);
        string endOfString = text.Substring(index + length);
        string cleanPath = startOfString + endOfString;

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(cleanPath);

        XmlNodeList xmlNode;
        xmlNode = xmlDoc.GetElementsByTagName("tuv");
        
       String word= xmlNode[1].ChildNodes.Item(0).InnerText.Trim();
       return word;
    }

  


}