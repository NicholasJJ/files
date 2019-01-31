using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabFromServer : MonoBehaviour
{
    public List<string> children;
    public string[] bits;
    private void Start()
    {
        WWW www = new WWW("https://api.github.com/repos/FRC4014/2019-robot-code/contents/src/main/java/frc/robot/vision");
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
    }


}
