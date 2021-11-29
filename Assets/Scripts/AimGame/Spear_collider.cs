using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_collider : MonoBehaviour
{
    public bool m_collision = false;
    public bool m_invalid = false;
    public bool m_valid = false;

    public GameObject m_enemy;

    private Movement script_enemy;
    private Gyroscope_managing script_gyro;

    public float m_multiplicateur = 1.0f; // Multiplicateur pour la barre de force

    void Start()
    {
        script_enemy = m_enemy.GetComponent<Movement>();
        script_gyro = GetComponent<Gyroscope_managing>();

    }

    void OnTriggerEnter(Collider col)
    {
        if (!m_collision) // N'a pas encore touché le pavois
        {
            m_collision = true; // Touche

            script_enemy.StopCOCO(); // Stop le mouvement de l'enemie

            script_gyro.m_start_moving = false; // Arretr le mouvement de la lance

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
                
                //Debug.Log(GameManager.instance.m_Game2_Result);

                GameManager.instance.NextGame(); // Lance le prochain mini - jeu
            }

            else if (col.name == "Invalid_zone") // Touche la mauvaise partie du pavois
            {
                if (!m_invalid) // N'a pas touché la mauvaise partie
                {
                    m_invalid = true; //Touché invalide --> recommence

                    m_collision = false; // Reset pour détecter la futur collision
                    script_enemy.ResetPosition(); // Reset la position adverse
                    script_gyro.m_start_moving = true; // Permet à la lance d'être bougée
                    script_enemy.StartCOCO(); // Relance la routine de déplacement

                }
                else // A déjà touché la mauvaise partie
                {
                    // Perd et recommence depuis le jeu précédent (rythme)
                    m_invalid = true;
                    m_collision = false;
                }
            }

            else // Touche un collider qu'il n'était pas censé toucher
            {
                m_collision = false;
            }

        }
    }
}
