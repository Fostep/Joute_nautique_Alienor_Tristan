using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    public float m_speed; // Vitesse
    public bool m_active = false;
    public Coroutine m_coco;

    public GameObject m_player; // Joueur

    private Vector3 m_initPosition; // Position initiale

    void Start()
    {
        m_active = true;
        m_initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        m_speed = 15.0f;

    }

    // Start is called before the first frame update
    IEnumerator MoveForward()
    {
        // Then, pick our destination point offset from our current location.
        Vector3 m_targetPosition = new Vector3(transform.position.x, transform.position.y, m_player.transform.position.z); // position cible à atteindre
        
        while(transform.position != m_targetPosition) // Tant que nous ne sommes pas arrivés
        {
            transform.position = Vector3.MoveTowards(transform.position, m_targetPosition, m_speed * Time.deltaTime); // Déplacer
            yield return null; // Continuer
        }

        //transform.position = targetPosition;
    }

    public void StopCOCO()
    {
        StopCoroutine(m_coco);
    }

    public void StartCOCO()
    {
        
        m_coco = StartCoroutine(MoveForward());
    }

    public void ResetPosition() // Reset l'objet à sa position initiale
    {
        transform.position = m_initPosition;
    }
}
