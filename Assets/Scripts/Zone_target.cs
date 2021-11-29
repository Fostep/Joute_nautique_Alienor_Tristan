using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone_target : MonoBehaviour
{
    public Scrollbar m_bar;
    private float m_targetNew;

    private void OnTriggerStay2D(Collider2D col)
    {
        //Debug.Log("Collision");
        if(col.name == "Target") // Si la zone est avec la zone cible
        {
            //m_targetNew += 0.01f; // Augmente la jaugede victoire
        }
    }

    void Start()
    {
        //m_bar.size = 0.5f; // Commence à la moitié
        //m_targetNew = 0.5f;
    }

    void Update()
    {
        if (m_bar.size > 0) 
        {
            //m_targetNew -= 0.00002f; // Force de l'enemy, a modifier en fonction des adversaires
            //m_bar.size = m_targetNew; // Nouvelle position entre les 2 jauges
        }
        else
        {
            //m_targetNew = 0.0f; // Perdu
        }

    }
}
