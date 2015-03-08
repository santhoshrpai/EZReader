using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DictionaryModel
/// </summary>
public class DictionaryModel
{
    private string audioUrl;

    public string AudioUrl
    {
        get { return audioUrl; }
        set { audioUrl = value; }
    }
    private string meaning;

    public string Meaning
    {
        get { return meaning; }
        set { meaning = value; }
    }
    private string sentenceUsage;

    public string SentenceUsage
    {
        get { return sentenceUsage; }
        set { sentenceUsage = value; }
    }


	public DictionaryModel()
	{
		//
		// TODO: Add constructor logic here
		//
        

	}
}