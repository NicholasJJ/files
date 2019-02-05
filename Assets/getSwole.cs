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
            float size = transform.localScale.x;
            if (Input.GetKey(KeyCode.Q))
            {
                transform.localScale = transform.localScale + new Vector3(resizeSpeed * size,0,resizeSpeed * size);
            }
            else if (Input.GetKey(KeyCode.E) && transform.localScale.x > 1)
            {
                transform.localScale = transform.localScale - new Vector3(resizeSpeed * size, 0, resizeSpeed * size);
            }
        }
    }
}
