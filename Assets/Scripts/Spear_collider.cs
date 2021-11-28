using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_collider : MonoBehaviour
{
    public bool m_collision = false;
    public bool m_invalid = false;
    public bool m_valid = false;

    public GameObject m_enemy;

    public float m_multiplicateur = 1.0f; // Multiplicateur pour la barre de force

    void OnTriggerEnter(Collider col)
    {
        if (!m_collision) // N'a pas encore touché le pavois
        {
            m_collision = true; // Touche
            Movement script_enemy = m_enemy.GetComponent<Movement>();
            script_enemy.StopCOCO();
            //Debug.Log(col.name);

            if (col.name == "Valid_Zone_0" || col.name == "Valid_Zone_1" || col.name == "Valid_Zone_2") // Touche une des bonnes parties du pavois
            {
                m_valid = true; // Touché valide

                if (col.name == "Valid_Zone_0") // Visée  correct
                {
                    m_multiplicateur = 1.25f;
                }

                if (col.name == "Valid_Zone_1") // Bonne visée
                {
                    m_multiplicateur = 1.5f;
                }

                if (col.name == "Valid_Zone_2") // Excellente visée
                {
                    m_multiplicateur = 1.75f;
                }

                GameManager.instance.m_Game2_Result = m_multiplicateur;
                Debug.Log(GameManager.instance.m_Game2_Result);

                GameManager.instance.NextGame();
            }

            else if (col.name == "Invalid_zone") // Touche la mauvaise partie du pavois
            {
                if (!m_invalid) // N'a pas touché la mauvaise partie
                {
                    m_invalid = true; //Touché invalide --> recommence

                }
                else // A déjà touché la mauvaise partie
                {
                    // Perd et recommence depuis le jeu précédent (rythme)
                }
            }

            else // Touche un collider qu'il n'était pas censé toucher
            {
                m_collision = false;
            }

        }
    }
}
