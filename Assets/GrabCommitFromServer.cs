using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabCommitFromServer : MonoBehaviour
{
    public string[] retrived;
    public GameObject name;
    public GameObject date;
    public GameObject message;

    public void getCommit(string hash, string location)
    {
        Debug.Log("hash is " + hash);
        WWW www = new WWW("https://api.github.com/repos/" + location + "/commits/" + hash);
        StartCoroutine(get(www));
    }
    IEnumerator get(WWW req)
    {
        yield return req;
        Debug.Log(req.text);
        retrived = req.text.Split(new string[] { " " }, System.StringSplitOptions.None);
        for(int i = 0; i <= retrived.Length - 2; i++)
        {
            if (retrived[i] == "\"name\":")
            {
                string AName = "";
                for (int n = 1; retrived[i + n] != ""; n++)
                {
                    AName = AName + retrived[i + n] + " ";
                }
                name.GetComponent<Text>().text = AName.Substring(1, retrived[i + 1].Length - 4);
            }
            else if (retrived[i] == "\"date\":")
            {
                date.GetComponent<Text>().text = retrived[i + 1].Substring(1, retrived[i + 1].Length - 4);
            }
            else if (retrived[i] == "\"message\":")
            {
                string AMessage = "";
                for (int n = 1; retrived[i + n] != ""; n++)
                {
                    AMessage = AMessage + retrived[i + n] + " ";
                }
                //Debug.Log(AMessage);
                message.GetComponent<Text>().text = AMessage.Substring(1, retrived[i + 1].Length - 3);
            }
        }
    }
}
