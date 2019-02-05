using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class grabFromServer : MonoBehaviour
{

    public string gitLocation;
    public string ogGitLocation;
    public List<string> children;
    public string[] bits;
    private void Start()
    {
        WWW www = new WWW("https://api.github.com/repos/" + ogGitLocation + "/contents" + gitLocation + "?client_id=eeceae9fffdbb3cf7f36&client_secret=5af051d8b21faead94ec443dc2ca42003111ea46");
        StartCoroutine(start(www));
    }
    IEnumerator start(WWW req)
    {
        yield return req;
        Debug.Log(req.text);
        bits = req.text.Split(new string[] { " " },System.StringSplitOptions.None);
        for (int i = 0; i <= bits.Length - 2; i++)
        {
            if(bits[i] == "\"name\":")
            {
                string kidName = "";
                for(int n = 1; bits[i+n] != ""; n++)
                {
                    kidName = kidName + bits[i + n] + " ";
                }
                children.Add(kidName.Remove(kidName.Length - 4).Substring(1));
            }
        }
        gameObject.GetComponent<SproutChildren>().Sprout(children.ToArray(), gitLocation, ogGitLocation);
    }


}
