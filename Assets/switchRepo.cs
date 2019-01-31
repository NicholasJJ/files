using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchRepo : MonoBehaviour
{
    public Text repoText;
    public GameObject contents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void redo()
    {
        Debug.Log("button pressed");
        GameObject.Destroy(GameObject.Find("Contents"));
        GameObject newContents = Instantiate(contents);
        newContents.transform.position = transform.position + Vector3.down;
        newContents.GetComponent<grabFromServer>().ogGitLocation = repoText.text;
    }
}
