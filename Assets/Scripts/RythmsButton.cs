using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmsButton : MonoBehaviour
{

    public string m_name;
    public bool m_buttonType;//True = B, False = A

    private void Awake()
    {
        Debug.Log(m_buttonType);
    }

}
