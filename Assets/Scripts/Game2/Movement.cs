using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour

{
    public float m_speed; // Vitesse
    public bool m_active = false;
    public Coroutine m_coco;
    public Coroutine m_coPos;


    public GameObject m_player; // Joueur

    //public GameObject m_message;
    private Text m_message_text;

    private Vector3 m_initPosition; // Position initiale

    void Start()
    {
        m_active = true;
        m_initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        m_speed = 15.0f;

        //m_message.SetActive(false); //m_message.GetComponent<Renderer>().enabled = false; --> hide

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

        StartReset("Vous avez manqué le pavois !");

        //transform.position = targetPosition;
    }

    public void StopCOCO()
    {
        StopCoroutine(m_coco);
    }

    public void StartCOCO()
    {
        //m_message.SetActive(false);

        if (m_coco != null)
        {
            StopCOCO();
        }
        
        m_coco = StartCoroutine(MoveForward());
        //m_message.SetActive(false);
       }

    public IEnumerator ResetPosition(string p_message) // Reset pos objet et texte
    {
        transform.position = m_initPosition;
        //m_message.SetActive(true);
        //m_message_text.text = p_message;

        yield return new WaitForSeconds(1.0f);

        StartCOCO();
    }

    public void StartReset(string p_message)
    {

        if (m_coPos != null)
        {
            StopCoroutine(m_coPos);
        }

        m_coPos = StartCoroutine(ResetPosition(p_message));
    }
}
