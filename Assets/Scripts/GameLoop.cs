using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLoop : MonoBehaviour {

    private Timer m_timer;
    private UIHandler m_ui;
    private WaveHandler m_wave;

    [SerializeField]
    private Text m_victor;

    private bool m_showControls = false;
    private bool m_inGame = false;
    private bool m_beginning = false;

    void Start()
    {
        m_ui = FindObjectOfType<UIHandler>();
        m_timer = FindObjectOfType<Timer>();
        m_wave = FindObjectOfType<WaveHandler>();
        m_ui.Fade(3, true);
    }

    private IEnumerator BeginGame()
    {
        m_beginning = true;
        m_ui.Fade(0, true);
        m_ui.Fade(1, false);
        m_ui.Fade(3, false);
        m_timer.Reset();
        m_wave.Begin();

        StartCoroutine(ShowControls());
        
        ScoreHandler.Reset();
        yield return new WaitForSeconds(3.0f);
        m_timer.StartTimer();
        m_inGame = true;
        m_beginning = false;
    }

    private IEnumerator ShowControls()
    {
        m_ui.Fade(2, true);
        m_showControls = true;
        yield return new WaitWhile(() => { return m_wave.Wave == 0 && m_showControls; });
        m_ui.Fade(2, false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && !m_inGame && !m_beginning) { StartCoroutine(BeginGame()); }

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
                m_showControls = false;
                m_victor.text = victor + "\n" + score.ToString(ScoreHandler.Format);
                m_wave.Reset();
            }
        }
    }
}
