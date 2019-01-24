using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraController : MonoBehaviour
{
    public Vector3 lookRot;
    public Vector3 lookPos;
    public float turnRate;
    public float moveRate;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        lookRot = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        lookPos = Vector3.zero;
        //rotation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            lookRot.y = lookRot.y -turnRate;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            lookRot.y = lookRot.y + turnRate;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            lookRot.x = lookRot.x -turnRate;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            lookRot.x = lookRot.x + turnRate;
        }
        transform.localRotation = Quaternion.Euler(lookRot);


        //position
        if (Input.GetKey(KeyCode.A))
        {
            lookPos.x = - moveRate;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            lookPos.x =  + moveRate;
        }
        if (Input.GetKey(KeyCode.W))
        {
            lookPos.z =  moveRate;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            lookPos.z =  -moveRate;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            lookPos.y = moveRate;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            lookPos.y = -moveRate;
        }
        transform.Translate(lookPos);

        //read what you see
        RaycastHit hrit;
        Ray h = new Ray(gameObject.transform.position, gameObject.transform.forward);
        if (Physics.Raycast(h, out hrit))
        {
            text.GetComponent<Text>().text = hrit.transform.name;
        }
        else
        {
            text.GetComponent<Text>().text = "";
        }
    }
}
