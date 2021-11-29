using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconMove : MonoBehaviour
{

    [SerializeField] private float m_speed;
    [SerializeField] private Color m_color;
    [SerializeField] private Color m_colorCanBeTouch;
    public bool m_hasBeenTouched;

    public bool m_iconType;//True = B, False = A
    private Image m_image;

    private void Start()
    {
        m_hasBeenTouched = false;
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
            RythmGameManager.instance.ButtonToClick(m_iconType, this);
            m_image.color = m_colorCanBeTouch;
        }
    }


    private void OnTriggerExit2D(Collider2D p_other)
    {
        if (p_other.GetComponent<RythmChecker>())
        {
            RythmGameManager.instance.ButtonToUnclick(m_iconType);
            m_image.color = m_color;
        }
    }
}
