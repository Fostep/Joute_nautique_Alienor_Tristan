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
    Rigidbody2D m_rb;

    [SerializeField] float m_strengh;
    [SerializeField] private float m_maxSpeedY_Up;
    [SerializeField] private float m_maxSpeedY_Down;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        m_bar.size = 0.5f; // Commence à la moitié
        m_targetNew = 0.5f;
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("tap");
                m_rb.AddForce(Vector2.up * m_strengh, ForceMode2D.Impulse);
            }
        }

        if (m_rb.velocity.y > m_maxSpeedY_Up)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.y, m_maxSpeedY_Up);
        }

        if (m_rb.velocity.y < m_maxSpeedY_Down)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.y, m_maxSpeedY_Down);
        }


        if (isMoving)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
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

        if (m_bar.size == 1)
        {
            //GameManager.instance.Victory();
        }
        else if (m_bar.size == 0)
        {
            //GameManager.instance.Replay();
        }
    }

    void OnTriggerEnter2D(Collider2D p_col)
    {
        if (p_col.name == "Limit_Bot" || p_col.name == "Limit_Top")
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
}
