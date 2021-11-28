using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    public float m_speed; // Vitesse
    public bool m_active = false;
    public Coroutine m_coco;

    public GameObject m_player;

    void Start()
    {
        m_active = true;
        
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

    // Update is called once per frame
    public void StopCOCO()
    {
        StopCoroutine(m_coco);
    }

    public void StartCOCO()
    {
        
        m_coco = StartCoroutine(MoveForward()); // StopCoroutine(coco);
    }
}
