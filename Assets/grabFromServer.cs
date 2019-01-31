using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class grabFromServer : MonoBehaviour
{
    //[System.Serializable]
    //public class TokenClassName
    //{
    //    public string access_token;
    //}
    //private static IEnumerator GetAccessToken()
    //{
    //    Dictionary<string, string> content = new Dictionary<string, string>();
    //    //Fill key and value
    //    content.Add("grant_type", "client_credentials");
    //    content.Add("client_id", "login-secret");
    //    content.Add("client_secret", "secretpassword");

    //    UnityWebRequest www = UnityWebRequest.Post("https://api.github.com//oauth/token", content);
    //    //Send request
    //    yield return www.Send();

    //    if (!www.isNetworkError)
    //    {
    //        string resultContent = www.downloadHandler.text;
    //        TokenClassName json = JsonUtility.FromJson<TokenClassName>(resultContent);
    //        Debug.Log(resultContent);
    //        //Return result
    //        yield return json.access_token;
    //        Debug.Log("access token is" + json.access_token);
    //    }
    //    else
    //    {
    //        //Return null
    //        yield return "";
    //        Debug.Log("couldn't find access token");
    //    }
    //}

    //[System.Serializable]
    //public class MeasurementClassName
    //{
    //    public string Measurements;
    //}

    //private static IEnumerator GetMeasurements()
    //{
    //    Dictionary<string, string> content = new Dictionary<string, string>();
    //    //Fill key and value
    //    content.Add("Sampling", "Auto");
    //    content.Add("client_secret", "secretpassword");

    //    UnityWebRequest www = UnityWebRequest.Post("https://api.github.com/repos/FRC4014/2019-robot-code/contents", content);

    //    string token = null;

    //    //yield return GetAccessToken();
           
    //    www.SetRequestHeader("Authorization", "Bearer " + GetAccessToken());
    //    www.Send();

    //    if (!www.isNetworkError)
    //    {
    //        yield return www.downloadHandler.text;
    //        Debug.Log("thing 1"+www.downloadHandler.text);
    //    }
    //    else
    //    {
    //        //Return null
    //        yield return "";
    //    }
    //}

    //private void Start()
    //{
    //    StartCoroutine(GetAccessToken());
    //}

    public string gitLocation;
    public string ogGitLocation;
    public List<string> children;
    public string[] bits;
    private void Start()
    {
        //WWW www = new WWW("https://api.github.com/repos/FRC4014/2019-robot-code/contents" + gitLocation + "?client_id=eeceae9fffdbb3cf7f36&client_secret=5af051d8b21faead94ec443dc2ca42003111ea46");
        //WWW www = new WWW("https://api.github.com/repos/pippinbarr/itisasifyouweredoingwork/contents" + gitLocation + "?client_id=eeceae9fffdbb3cf7f36&client_secret=5af051d8b21faead94ec443dc2ca42003111ea46");
        WWW www = new WWW("https://api.github.com/repos/" + ogGitLocation+ "/contents" + gitLocation + "?client_id=eeceae9fffdbb3cf7f36&client_secret=5af051d8b21faead94ec443dc2ca42003111ea46");
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
                children.Add(bits[i + 1].Remove(bits[i + 1].Length - 3).Substring(1));
            }
        }
        gameObject.GetComponent<SproutChildren>().Sprout(children.ToArray(), gitLocation, ogGitLocation);
    }


}
