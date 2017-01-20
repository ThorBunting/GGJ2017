using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLoop : MonoBehaviour {

    private Timer m_timer;
    private UIHandler m_ui;

    [SerializeField]
    private Text m_victor;

    private bool m_inGame = false;

    void Start()
    {
        m_ui = FindObjectOfType<UIHandler>();
        m_timer = FindObjectOfType<Timer>();
    }

    private IEnumerator BeginGame()
    {
        m_ui.Fade(0, true);
        m_ui.Fade(1, false);
        m_timer.Reset();
        ScoreHandler.Reset();
        yield return new WaitForSeconds(3.0f);
        m_timer.StartTimer();
        m_inGame = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !m_inGame) { Debug.Log("Begin"); StartCoroutine(BeginGame()); }

        if(m_inGame)
        {
            if(m_timer.isActive)
            {

            }
            else
            {
                m_inGame = false;
                int winner = ScoreHandler.Higher();
                int score = (int)ScoreHandler.Get(winner % 2);
                string victor;
                switch(winner)
                {
                    case 0:
                        victor = "Player 1 Wins!";
                        break;
                    case 1:
                        victor = "Player 2 Wins!";
                        break;
                    default:
                        victor = "Draw!";
                        break;
                }
                m_ui.Fade(0, false);
                m_ui.Fade(1, true);
                m_victor.text = victor + "\n" + score.ToString(ScoreHandler.Format);
            }
        }
    }
}
