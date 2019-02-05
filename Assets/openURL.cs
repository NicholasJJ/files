using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openURL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Application.OpenURL("https://www.google.com");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hrit;
        //    Ray h = new Ray(gameObject.transform.position, gameObject.transform.forward);
        //    if (Physics.Raycast(h, out hrit))
        //    {
        //        string gitlocation = hrit.transform.gameObject.GetComponent<grabFromServer>().gitLocation;
        //        string ogGitlocation = hrit.transform.gameObject.GetComponent<grabFromServer>().ogGitLocation;
        //        Application.OpenURL("https://github.com/" + ogGitlocation + "/blob/master" + gitlocation);
        //    }
        //}
    }
}
