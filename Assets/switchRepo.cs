﻿using System.Collections;
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            redo();
        }
    }
    public void redo()
    {
        Debug.Log("button pressed");
        transform.SetParent(null);
        GameObject.Destroy(GameObject.FindWithTag("root"));
        GameObject newContents = Instantiate(contents);
        newContents.transform.position = transform.position + 2*Vector3.down;
        newContents.GetComponent<grabFromServer>().ogGitLocation = repoText.text;
        transform.SetParent(newContents.transform);
    }
}
