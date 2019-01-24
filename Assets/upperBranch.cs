using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upperBranch : MonoBehaviour
{
    public List<string> lineList;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "")
        {
            GameObject.Destroy(gameObject);
        }
        gameObject.GetComponent<SproutChildren>().Sprout(lineList.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
