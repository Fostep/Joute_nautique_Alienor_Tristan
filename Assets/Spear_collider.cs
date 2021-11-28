using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_collider : MonoBehaviour
{
    public bool m_collision = false;
    public bool m_invalid = false;
    public bool m_valid = false;
    public float m_multiplicateur = 1.0f; // Multiplicateur pour la barre de force

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
        if(!m_collision) // N'a pas encore touch� le pavois
        {
            m_collision = true; // Touche

            Debug.Log(col.name);

            if(col.name == "Valid_Zone_0" || col.name == "Valid_Zone_1" || col.name == "Valid_Zone_2") // Touche une des bonnes parties du pavois
            {
                m_valid = true; // Touch� valide

                if(col.name == "Valid_Zone_0") // Vis�e  correct
                {
                    m_multiplicateur = 1.25f;
                }

                if (col.name == "Valid_Zone_0") // Bonne vis�e
                {
                    m_multiplicateur = 1.5f;
                }

                if (col.name == "Valid_Zone_0") // Excellente vis�e
                {
                    m_multiplicateur = 1.75f;
                }
            }

            else if(col.name == "Invalid_zone") // Touche la mauvaise partie du pavois
            {
                if (!m_invalid) // N'a pas touch� la mauvaise partie
                {
                    m_invalid = true; //Touch� invalide --> recommence

                }
                else // A d�j� touch� la mauvaise partie
                {
                    // Perd et recommence depuis le jeu pr�c�dent (rythme)
                }
            }

            else // Touche un collider qu'il n'�tait pas cens� toucher
            {
                m_collision = false;
            }

        }
    }
}
