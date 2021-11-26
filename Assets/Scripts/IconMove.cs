using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconMove : MonoBehaviour
{

    [SerializeField] private float m_speed;
    public bool m_iconType;//True = B, False = A
    private Image m_image;

    private void Start()
    {
        m_image = gameObject.GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * m_speed;
    }

    private void OnTriggerEnter2D(Collider2D p_other)
    {
        if (p_other.GetComponent<RythmChecker>())
        {
            GameManager.instance.ButtonToClick(m_iconType);
            m_image.color = Color.blue;
        }
    }


    private void OnTriggerExit2D(Collider2D p_other)
    {
        if (p_other.GetComponent<RythmChecker>())
        {
            GameManager.instance.ButtonToUnclick(m_iconType);
            m_image.color = Color.white;
        }
    }
}
