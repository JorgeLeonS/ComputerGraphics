using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escri1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            if (transform.position.z<1.8f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime);
            }
        }
        else if(Input.GetKey("s"))
        {
            if (transform.position.z > -1.8f)
            {
                transform.Translate(Vector3.back * Time.deltaTime);
            }
        }
    }
}
