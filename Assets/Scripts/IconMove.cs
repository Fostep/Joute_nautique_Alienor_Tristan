using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMove : MonoBehaviour
{

    public float m_speed;
    public bool m_iconType;//True = B, False = A

 
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * m_speed;
    }

    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.GetComponent<RythmChecker>())
        {
            GameManager.instance.ButtonToClick(m_iconType);
        }
    }

    private void OnTriggerExit(Collider p_other)
    {
        if (p_other.GetComponent<RythmChecker>())
        {
            GameManager.instance.ButtonToUnclick(m_iconType);
        }
    }
}
