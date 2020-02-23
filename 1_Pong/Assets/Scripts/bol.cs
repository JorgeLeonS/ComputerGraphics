using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < 4.2f)
            {
                transform.Translate(Vector3.right * Time.deltaTime);
            }
            /*
        if (transform.position.x > -4.2f)
            {
                transform.Translate(Vector3.left * Time.deltaTime);
            }
            /*
        if (transform.position.z < 1.8f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime);
            }else if(transform.position.z > 4.2f || transform.position.x < -1.8f){
                transform.Rotate(0.0f, position.Y + 90 , 0.0f);
                transform.Translate(Vector3.forward * 0);
            }
            
        if (transform.position.z < 1.8f)
            {xsxw
                transform.Translate(Vector3.back * Time.deltaTime);
            }
            */
    }
}
