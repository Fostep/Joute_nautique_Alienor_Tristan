using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_collider_0 : MonoBehaviour
{
    public bool m_collision = false;
    public bool m_invalid = false;
    public bool m_valid = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        m_collision = true;
        Debug.Log(col.name);

        if(col.name == "Valid_Zone") // Touche la bonne partie du pavois
        {
            m_valid = true;
        }
        else if(col.name == "Invalid_zone") // Touche la mauvaise partie du pavois
        {
            m_invalid = true;
        }
        else
        {
            m_collision = false;
        }
    }
}
