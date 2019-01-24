using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class branch : MonoBehaviour
{
    public StreamReader reader;
    private bool done = false;
    public string[] lines;
    public List<string> lineList;
    // Start is called before the first frame update
    void Start()
    {
        reader = new StreamReader("assets/test");
        //split the text file into it's lines
        lineList = new List<string>();
        done = false;
        for (int i = 0; !done; i++)
        {
            string info = reader.ReadLine();
            if (info != null)
            {
                lineList.Add(info.TrimStart("/".ToCharArray()));
            }
            else
            { 
                done = true;
            }
        }
        gameObject.GetComponent<SproutChildren>().Sprout(lineList.ToArray());
    }
}
