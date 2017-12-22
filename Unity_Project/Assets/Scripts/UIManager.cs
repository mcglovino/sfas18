using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    // --------------------------------------------------------------

    [SerializeField]
    Text m_Player1ScoreText;

    [SerializeField]
    Text m_Player2ScoreText;

    // --------------------------------------------------------------

    int m_Player1Score = 0;
    int m_Player2Score = 0;

    // --------------------------------------------------------------

    public Slider p1Slider;
    public Slider p2Slider;
    public GameObject p1Fill;
    public GameObject p2Fill;

    private void Start()
    {
        p1Slider.value = 0;
        p2Slider.value = 0;
        p1Fill.SetActive(false);
        p2Fill.SetActive(false);
    }

    void OnEnable()
    {
        DeathTrigger.OnPlayerDeath += OnUpdateScore;
        Spin.OnCollect += OnUpdateScore;
    }

    void OnDisable()
    {
        DeathTrigger.OnPlayerDeath -= OnUpdateScore;
        Spin.OnCollect -= OnUpdateScore;
    }

    private void Update()
    {
        p1Slider.value = m_Player1Score;
        p2Slider.value = m_Player2Score;
        if (m_Player1Score > 0)
            p1Fill.SetActive(true);
        if (m_Player2Score > 0)
            p2Fill.SetActive(true);
        if (m_Player1Score == 25)
        {
            SceneInfo.Win = 1;
            SceneManager.LoadScene(1);
        }
        if (m_Player2Score == 25)
        {
            SceneInfo.Win = 2;
            SceneManager.LoadScene(1);
        }

    }

    void OnUpdateScore(int playerNum)
    {
        if(playerNum == 1)
        {
            m_Player1Score += 1;
            m_Player1ScoreText.text = "" + m_Player1Score;
        }
        else if(playerNum == 2)
        {
            m_Player2Score += 1;
            m_Player2ScoreText.text = "" + m_Player2Score;
        }
    }
}
