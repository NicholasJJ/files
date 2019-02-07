using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutChildren : MonoBehaviour
{
    public GameObject branchObject;
    public int childrenCount;

    public void Sprout(string[] files, string parentGitLocation, string ogLocation)
    {
        childrenCount = files.Length;
        if(childrenCount == 0)
        {
            if (gameObject.tag == "root")
            {
                GameObject.Find("Main Camera").transform.SetParent(null);
            }
            GameObject.Destroy(gameObject);
        }
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject newBranch = Instantiate(branchObject, transform);
            newBranch.name = files[i];
            if(childrenCount == 1)
            {
                newBranch.transform.localPosition = Vector3.up;
                newBranch.transform.localScale = new Vector3(.9f, 1, .9f);
            }
            else
            {
                newBranch.transform.localPosition = new Vector3(.25f * Mathf.Sin((i * 2 * Mathf.PI) / childrenCount), 1, .25f * Mathf.Cos((i * 2 * Mathf.PI) / childrenCount));
                float roughchildsize = Mathf.Sqrt(.25f - .125f * Mathf.Cos((2 * Mathf.PI) / childrenCount));
                float childsize = roughchildsize * (-5 / (-3.5f - (.9f * childrenCount)));
                if (childrenCount < 3)
                {
                    childsize = .499f;
                }
                newBranch.transform.localScale = new Vector3(childsize, 1, childsize);
            }
            string gitLocation = parentGitLocation + "/" + files[i];
            newBranch.GetComponent<grabFromServer>().gitLocation = gitLocation;
            newBranch.GetComponent<grabFromServer>().ogGitLocation = ogLocation;
        }
    }
}
