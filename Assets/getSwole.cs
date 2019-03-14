using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getSwole : MonoBehaviour
{
    public bool isTree;
    public bool isRoot;
    public float resizeSpeed;
    private float yspeed;
    // Start is called before the first frame update
    void Start()
    {
        if (isTree)
        {
            yspeed = 1;
        }
        else
        {
            yspeed = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoot && Cursor.lockState == CursorLockMode.Locked)
        {
            float size = transform.localScale.x;
            if (Input.GetKey(KeyCode.Q))
            {
                transform.localScale = transform.localScale + new Vector3(resizeSpeed * size,yspeed * resizeSpeed * size,resizeSpeed * size);
            }
            else if (Input.GetKey(KeyCode.E) && transform.localScale.x > 1)
            {
                transform.localScale = transform.localScale - new Vector3(resizeSpeed * size, yspeed * resizeSpeed * size, resizeSpeed * size);
            }
        }
    }
}
