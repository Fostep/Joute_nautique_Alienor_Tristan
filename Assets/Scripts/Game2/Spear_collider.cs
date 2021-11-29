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
        if (!m_collision) // N'a pas encore touch� le pavois
        {
            m_collision = true; // Touche

            script_enemy.StopCOCO(); // Stop le mouvement de l'enemie

            script_gyro.m_start_moving = false; // Arretr le mouvement de la lance

            //Debug.Log(col.name);

            if (col.name == "Valid_Zone_0" || col.name == "Valid_Zone_1" || col.name == "Valid_Zone_2") // Touche une des bonnes parties du pavois
            {
                m_valid = true; // Touch� valide

                if (col.name == "Valid_Zone_0") // Vis�e  correct
                {
                    m_multiplicateur = 1.25f;
                }

                if (col.name == "Valid_Zone_1") // Bonne vis�e
                {
                    m_multiplicateur = 1.5f;
                }

                if (col.name == "Valid_Zone_2") // Excellente vis�e
                {
                    m_multiplicateur = 1.75f;
                }

                GameManager.instance.m_Game2_Result = m_multiplicateur;
                GameManager.instance.NextGame(); // Lance le prochain mini - jeu
            }

            else if (col.name == "Invalid_Zone") // Touche la mauvaise partie du pavois
            {
                Debug.Log("loup�");
                if (!m_invalid) // Touche la mauvaise partie une premiere fois
                {
                    m_invalid = true; //Touch� invalide --> recommence

                    m_collision = false; // Reset pour d�tecter la futur collision
                    script_enemy.StartReset("Mauvaise partie du pavois"); // Reset la position adverse
                    script_gyro.m_start_moving = true; // Permet � la lance d'�tre boug�e
                }
                else // A d�j� touch� la mauvaise partie
                {
                    // Perd et recommence depuis le jeu pr�c�dent (rythme)
                    m_invalid = false;
                    m_collision = false;
                    GameManager.instance.Replay();
                }
            }

            else // Touche un collider qu'il n'�tait pas cens� toucher
            {
                m_collision = false;
            }

        }
    }
}
