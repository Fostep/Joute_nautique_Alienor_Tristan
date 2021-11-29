using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndicationPop : MonoBehaviour
{
    [SerializeField] GameObject[] m_indications;
    [SerializeField] float m_fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject indic in m_indications)
        {
            indic.SetActive(false);
        }
    }

    public void GiveIndication(int p_index)
    {
        m_indications[p_index].SetActive(true);
        StartCoroutine(Fade(p_index));

    }

    IEnumerator Fade(int p_index)
    {
        TextMeshPro text = m_indications[p_index].GetComponent<TextMeshPro>();
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * m_fadeTime));
        }
        m_indications[p_index].SetActive(false);
        yield return null;
    }

}
