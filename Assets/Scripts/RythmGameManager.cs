using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmGameManager : MonoBehaviour
{
    public static RythmGameManager instance;

    public bool m_isTouchableA;
    public bool m_isTouchableB;
    public int m_score;
    public GameObject m_indicator;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        m_isTouchableA = false;
        m_isTouchableB = false;
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
}
