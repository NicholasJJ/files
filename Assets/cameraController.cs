using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraController : MonoBehaviour
{
    public float turnRate;
    public float moveRate;
    public Vector3 lookPos;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void LateUpdate()
    {
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

        //if cursor is locked, move
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            //transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * turnRate , Input.GetAxis("Mouse X") * turnRate, 0);
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnRate);
            transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * turnRate);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

            Vector3 moveinp = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            transform.Translate(moveinp * moveRate * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveinp) * moveRate * Time.deltaTime);
            if (Input.GetMouseButtonDown(0))
            {
                string gitlocation = hrit.transform.gameObject.GetComponent<grabFromServer>().gitLocation;
                string ogGitlocation = hrit.transform.gameObject.GetComponent<grabFromServer>().ogGitLocation;
                Debug.Log(gitlocation);
                if(gitlocation == "")
                {
                    Application.OpenURL("https://github.com/" + ogGitlocation);
                }
                else
                {
                    Application.OpenURL("https://github.com/" + ogGitlocation + "/blob/master" + gitlocation);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("space clicked!");
                string ogGitlocation = hrit.transform.gameObject.GetComponent<grabFromServer>().ogGitLocation;
                string hash = hrit.transform.gameObject.GetComponent<grabFromServer>().myHash;
                gameObject.GetComponent<GrabCommitFromServer>().getCommit(hash, ogGitlocation);
            }
        }

        //change cursor state
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetMouseButtonDown(0) && GameObject.Find("writeText").GetComponent<InputField>().isFocused == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
