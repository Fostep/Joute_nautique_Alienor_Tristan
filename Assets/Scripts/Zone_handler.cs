using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone_handler : MonoBehaviour
{
    public bool isMoving;
    public Scrollbar m_bar;
    private float m_targetNew;
    public GameObject m_target;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        m_bar.size = 0.5f; // Commence à la moitié
        m_targetNew = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        }

        if (m_bar.size > 0)
        {
            m_targetNew -= 0.00002f; // Force de l'enemy, a modifier en fonction des adversaires
            m_bar.size = m_targetNew; // Nouvelle position entre les 2 jauges
        }
        else
        {
            m_targetNew = 0.0f; // Perdu
        }
    }

    void OnTriggerEnter2D(Collider2D p_col)
    {
        if(p_col.name == "Limit_Bot" || p_col.name == "Limit_Top")
        {
            isMoving = false;
        }
    }

    void OnTriggerStay2D(Collider2D p_col)
    {
        if (p_col.name == "Target")
        {
            m_targetNew += 0.01f; // Augmente la jaugede victoire
        }
    }

    public void PushHandler()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 100f, transform.position.z);
    }
}
