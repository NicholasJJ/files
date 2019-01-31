using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getSwole : MonoBehaviour
{
    public bool isRoot;
    public float resizeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoot)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.localScale = transform.localScale + new Vector3(resizeSpeed,0,resizeSpeed);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.localScale = transform.localScale - new Vector3(resizeSpeed, 0, resizeSpeed);
            }
        }
    }
}
