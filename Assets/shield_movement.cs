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
       transform.position -= Vector3.forward * Time.deltaTime * speed;
    }
}
