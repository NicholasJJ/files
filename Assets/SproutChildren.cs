using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutChildren : MonoBehaviour
{
    public GameObject branchObject;
    public List<string> children;
    public int childrenCount;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Sprout(string[] lines)
    {
        // split each line into an array of it's files
        string[][] files = new string[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            files[i] = lines[i].Split(new string[] { "/" }, System.StringSplitOptions.None);
        }

        children = new List<string>();
        for (int p = 0; p < files.Length; p++)
        {
            if (files[p] != null && !children.Contains(files[p][0]))
            {
                children.Add(files[p][0]);
                childrenCount++;
            }
        }

        List<string> noGoList = new List<string>();
        for (int j = 0; j < files.Length; j++)
        {
            if (files[j] != null && !noGoList.Contains(files[j][0]))
            {
                GameObject newBranch = Instantiate(branchObject, transform);
                newBranch.transform.localPosition = new Vector3(.25f * Mathf.Sin((j * 2 * Mathf.PI) / childrenCount), 1, .25f * Mathf.Cos((j * 2 * Mathf.PI) / childrenCount));
                float roughchildsize = Mathf.Sqrt(.25f - .125f*Mathf.Cos((2 * Mathf.PI) / childrenCount));
                //float childsize = .5f*roughchildsize/Mathf.Sqrt(.25f+ (roughchildsize*roughchildsize));
                float childsize = roughchildsize * (-5/(-3.5f-(.9f*childrenCount)));
                if (childrenCount < 3)
                {
                    childsize = .499f;
                }
                newBranch.transform.localScale = new Vector3(childsize, 1, childsize);
                newBranch.name = files[j][0];
                float size = 0;
                for (int k = 0; k < files.Length; k++)
                {
                    if (files[k][0] == files[j][0])
                    {
                        newBranch.GetComponent<upperBranch>().lineList.Add(lines[k].TrimStart((files[j][0]).ToCharArray()).TrimStart("/".ToCharArray()));
                        size++;
                    }
                }
                noGoList.Add(files[j][0]);
            }
        }
    }
}
