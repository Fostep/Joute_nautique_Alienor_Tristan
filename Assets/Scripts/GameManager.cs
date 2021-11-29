using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject m_enemy_G2; // Enemie qu idémarre le jeu n 2
    [SerializeField] public GameObject m_spear; // Active mouvement lance
    [SerializeField] public GameObject m_rythmGame; // Active mouvement lance
    public static GameManager instance;

    [SerializeField] float m_game1Duration;

    public enum CurrentGame
    {
        Menu = 0,
        GameOne = 1,
        GameTwo = 2,
        GameThree = 3
    };

    public CurrentGame m_turn;

    public float m_Game2_Result;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        m_turn = CurrentGame.Menu;
        m_rythmGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextGame()
    {
        if(m_turn != CurrentGame.GameThree)
        {
            m_turn++;
        }
        else
        {
            m_turn = 0;
        }

        if(m_turn == CurrentGame.GameTwo)
        {
            m_rythmGame.SetActive(false);
            //Debug.Log("Lancement G2");
            m_enemy_G2.GetComponent<Movement>().StartCOCO();
            m_spear.GetComponent<Gyroscope_managing>().m_start_moving = true;
            //Debug.Log(m_spear.GetComponent<Gyroscope_managing>().m_start_moving);
        }

        if (m_turn == CurrentGame.GameOne)
        {
            m_rythmGame.SetActive(true);
            StartCoroutine(Game1Duration());
        }
    }

    IEnumerator Game1Duration()
    {
        yield return new WaitForSeconds(m_game1Duration);
        NextGame();
    }
}
