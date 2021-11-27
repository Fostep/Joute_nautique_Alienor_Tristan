using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_movement : MonoBehaviour    
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // movingForward allows to move the shield forward and to stop it if necessary
    // No return
    private void movingForward(bool activate)
    {
        if (activate)
        {
            transform.position -= Vector3.forward * Time.deltaTime * speed;
        }
        else
        {
            transform.position = Vector3.zero;
        }
    }
}
