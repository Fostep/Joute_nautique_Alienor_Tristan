using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public bool m_isTouchableA;
    public bool m_isTouchableB;
    public int m_score;
    public GameObject m_indicator;

    void Awake()
    {
        instance = this;
        m_isTouchableA = false;
        m_isTouchableB = false;
    }

    private void Start()
    {
        m_indicator = 
    }

    public void ButtonToClick(bool p_type)//True = B, False = A
    {
        if (p_type) m_isTouchableB = true;
        else m_isTouchableA = true;
    }
    
    public void ButtonToUnclick(bool p_type)//True = B, False = A
    {
        if (p_type) m_isTouchableB = false;
        else m_isTouchableA = false;
    }

    public void PointCount(bool p_type)
    {
        if ((!p_type && m_isTouchableA) || (p_type && m_isTouchableB)) m_score++;
        //else m_score--;

        Debug.Log("score : " + m_score + ", boutton : " + p_type);
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray*//*, out hit*//*))
                    {
                        Debug.Log("lol");
                        *//*if (hit.collider != null)
                        {
                            PointCount(hit.collider.GetComponent<RythmsButton>().m_buttonType);
                            Debug.Log("name : " + hit.collider.GetComponent<RythmsButton>().m_name + ", type : " + hit.collider.GetComponent<RythmsButton>().m_buttonType);
                        }*//*
                    }
                }
            }
        }

    }*/
}
