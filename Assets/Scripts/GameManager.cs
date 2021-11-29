using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject m_enemy_G2; // Enemie qu idémarre le jeu n 2
    [SerializeField] public GameObject m_spear; // Active mouvement lance
    [SerializeField] public GameObject m_rythmGame; // Active mouvement lance
    [SerializeField] public GameObject m_menu; // Active mouvement lance
    [SerializeField] public GameObject m_victoryScreen; // Active mouvement lance
    [SerializeField] public GameObject m_strenghGame; // Active mouvement lance
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

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Victory()
    {
        m_victoryScreen.SetActive(true);
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

         if (m_turn == CurrentGame.GameOne)
        {
            Debug.Log("Game One");
            m_rythmGame.SetActive(true);
            StartCoroutine(Game1Duration());
            m_menu.SetActive(false);
            m_rythmGame.GetComponent<RythmGameManager>().StartGame();
        }

        if (m_turn == CurrentGame.GameTwo)
        {
            Debug.Log("Game Two");
            m_enemy_G2.GetComponent<Movement>().StartCOCO();
            m_spear.GetComponent<Gyroscope_managing>().m_start_moving = true;
        }

        if (m_turn == CurrentGame.GameThree)
        {
            Debug.Log("Game Three");
            m_strenghGame.SetActive(true);
        }
    }

    IEnumerator Game1Duration()
    {
        yield return new WaitForSeconds(m_game1Duration);
        Debug.Log("end game one");
        m_rythmGame.GetComponent<RythmGameManager>().EndGame();
        m_rythmGame.SetActive(false);
        NextGame();
    }
}
