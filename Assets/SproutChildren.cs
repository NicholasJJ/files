using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutChildren : MonoBehaviour
{
    public GameObject branchObject;
    public int childrenCount;
    public bool isTree;

    public void Sprout(string[] files, string parentGitLocation, string ogLocation, float[] sizes, string[] Hashes)
    {
        childrenCount = files.Length;
        if(childrenCount == 0)
        {
            if (gameObject.tag == "root")
            {
                GameObject.Find("Main Camera").transform.SetParent(null);
            }
            //gameObject.GetComponentInParent<Renderer>().material.color = Color.green;
            //GameObject.Find(gameObject.name).GetComponent<Renderer>().material.color = Color.green;
            GameObject.Destroy(gameObject);
        }
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject newBranch = Instantiate(branchObject, transform);
            newBranch.name = files[i];
            if (isTree)
            {
                newBranch.transform.localPosition = new Vector3(0, 8, 0);
                newBranch.transform.localScale = new Vector3(.7f, .7f, .7f);
                if (childrenCount == 1)
                {
                    newBranch.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    float angle = i * (360 / childrenCount);
                    newBranch.transform.eulerAngles = new Vector3(0, angle, 40);
                    Debug.Log(360/childrenCount);
                }
            }
            else
            {
                if (childrenCount == 1)
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
            }
            string gitLocation = parentGitLocation + "/" + files[i];
            newBranch.GetComponent<grabFromServer>().gitLocation = gitLocation;
            newBranch.GetComponent<grabFromServer>().ogGitLocation = ogLocation;
            newBranch.GetComponent<grabFromServer>().myHash = Hashes[i];
            float color = sizes[i] / 10000;
            float saturation = 1;
            if (color > .8)
            {
                color = 2;
            } 
            else if (color == 0)
            {
                saturation = 0;
            }
            newBranch.GetComponent<Renderer>().material.color = Color.HSVToRGB(color, saturation, 1);
        }
    }
}
