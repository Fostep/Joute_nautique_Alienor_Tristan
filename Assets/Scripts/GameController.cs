using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public enum TurnState
    {
        None = 0,
        PlayerOne = 1,
        PlayerTwo = 2
    };

    public TurnState m_turn;
    public List<int> m_playerOneChecks;
    public List<int> m_playerTwoChecks;

    // Start is called before the first frame update
    void Start()
    {
        m_turn = TurnState.PlayerOne;
    }

    public void ChangeTurn(int p_iD)
    {
        if (m_turn == TurnState.PlayerOne)
        {
            m_playerOneChecks.Add(p_iD);
            m_turn = TurnState.PlayerTwo;

        }
        else if (m_turn == TurnState.PlayerTwo)
        {
            m_playerTwoChecks.Add(p_iD);
            m_turn = TurnState.PlayerOne;

        }

        Debug.Log("Current trun : " + m_turn);
        
    }

    public void ChecksDiagonals()
    {
        if (m_playerOneChecks.Contains(0) && m_playerOneChecks.Contains(4) && m_playerOneChecks.Contains(8))
        {
            Debug.Log("PlayerOne win !");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
