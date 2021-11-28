using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour, IPointerClickHandler//, IPointerEnterHandler
{
    public GameController m_game;
    public Sprite m_cross;
    public Sprite m_circle;
    public int m_iD;

    // Start is called before the first frame update
    void Start()
    {
        m_game = FindObjectOfType<GameController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //GetComponent<Image>().color = Color.black;

        if(m_game.m_turn == GameController.TurnState.PlayerOne)
        {
            GetComponent<Image>().sprite = m_cross;
        }
        else if(m_game.m_turn == GameController.TurnState.PlayerTwo)
        {
            GetComponent<Image>().sprite = m_circle;
        }

        m_game.ChangeTurn(m_iD);
        m_game.ChecksDiagonals();

          
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Passage");       
    }*/

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
