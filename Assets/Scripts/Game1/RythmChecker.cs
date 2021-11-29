using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmChecker : MonoBehaviour
{
    [SerializeField] int m_pointToGive;
    [SerializeField] int m_indicatorIndex;

    private void OnTriggerEnter2D(Collider2D p_collision)
    {
        RythmGameManager.instance.m_scoreToAdd = m_pointToGive;
        RythmGameManager.instance.m_indicatorIndex = m_indicatorIndex;
    }
}
