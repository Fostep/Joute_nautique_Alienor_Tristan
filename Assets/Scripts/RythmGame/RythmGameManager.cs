using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmGameManager : MonoBehaviour
{
    public static RythmGameManager instance;

    public bool m_isTouchableR;
    public bool m_isTouchableL;
    private IconMove m_nodeR;
    private IconMove m_nodeL;
    public int m_score;
    public int m_scoreToAdd;
    public GameObject m_indicator;
    public GameObject m_nodeGenerator;
    private IndicationPop m_indicatorPop;
    public int m_indicatorIndex;
    

    void StopCoco()
    {
        m_nodeGenerator.GetComponent<NodeGenerator>().StopAllCoroutines();
        m_indicator.GetComponent<IndicationPop>().StopAllCoroutines();
    }

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        m_isTouchableR = false;
        m_isTouchableL = false;
        m_indicatorPop = m_indicator.GetComponent<IndicationPop>();
    }

    public void StartGame()
    {
        m_nodeGenerator.GetComponent<NodeGenerator>().StartGame();
    }

    public void EndGame()
    {
        StopCoco();
        GameObject himself = GetComponent<GameObject>();
        himself.SetActive(false);
    }

    public void ButtonToClick(bool p_type, IconMove p_node)//True = Left, False = Right
    {
        if (p_type)
        {
            m_isTouchableL = true;
            m_nodeL = p_node;

        }
        else
        {
            m_isTouchableR = true;
            m_nodeR = p_node;
        }
    }

    public void ButtonToUnclick(bool p_type)//True = Left, False = Right
    {
        if (p_type)
        {
            m_isTouchableL = false;
            m_nodeL = null;

        }
        else
        {
            m_isTouchableR = false;
            m_nodeR = null;
        }
    }

    public void TouchDown(bool p_type)
    {
        if (m_nodeR != null || m_nodeL != null)
        {
            if ((!p_type && m_isTouchableR && !m_nodeR.m_hasBeenTouched) || (p_type && m_isTouchableL && !m_nodeL.m_hasBeenTouched))
            {
                if (p_type) m_nodeL.m_hasBeenTouched = true;
                else m_nodeR.m_hasBeenTouched = true;
                m_indicatorPop.GiveIndication(m_indicatorIndex);
                CountPoint();
            }
        }
        
        //else calcule de la distance pour savoir si node null ou si r se passe
        //mettre une limite de clic par seconde peut etre ?
    }

    private void CountPoint()
    {
        m_score += m_scoreToAdd;
        m_scoreToAdd = 0;
        Debug.Log("score : " + m_score);
    }
}
