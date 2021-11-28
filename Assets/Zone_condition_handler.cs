using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone_condition_handler : MonoBehaviour
{

    public Scrollbar m_bar;
    public bool m_active;
    private float m_handlerNew; // Nouvelle position du handler

    // Start is called before the first frame update
    void Start()
    {
        // Permet de changer la position de la barre bar.value = 1; 
        m_bar.value = 1;
        m_handlerNew = 1;
        m_active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_active && m_bar.value > 0) // Si actif et value > 0
        {
            m_handlerNew -= 0.0015f; // Fait descendre la position
        }

        m_bar.value = m_handlerNew; // Nouvelle position du handler
        
    }

    public void PushHandler()
    {
        m_handlerNew += 0.2f; // Augmente la position du handler
    }
}