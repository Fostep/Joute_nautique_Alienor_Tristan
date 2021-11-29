using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmChecker : MonoBehaviour
{
    [SerializeField] int m_pointToGive;

    private void OnTriggerEnter2D(Collider2D p_collision)
    {
        RythmGameManager.instance.m_scoreToAdd = m_pointToGive;
    }
}
