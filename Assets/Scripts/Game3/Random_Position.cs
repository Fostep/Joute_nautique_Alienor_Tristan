using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Position : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float y = Random.Range(-720.0f, 720.0f);
        Debug.Log(y);

        transform.position = new Vector3(transform.position.x, transform.position.y + y, transform.position.z);
    }

}
