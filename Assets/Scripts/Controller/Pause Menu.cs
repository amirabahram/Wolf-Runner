using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField]
    Text maxScore;
    [SerializeField]
    Text score;
    [SerializeField]
    Button resume;
    Text backgroundScore;
    int highScore;

    private void Start()
    {
        backgroundScore = GameObject.Find("Score").GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    private void OnEnable()
    {
        ObstacleCollector.OnPlayerDied += PausePanel;
    }
    private void OnDisable()
    {
        ObstacleCollector.OnPlayerDied -= PausePanel;
    }
    public void PausePanel(bool isEvent=false)
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        score.text = "Score : "+backgroundScore.text;
        if(Score.score>highScore)
        {
            highScore = Score.score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        maxScore.text = "High Score : "+PlayerPrefs.GetInt("HighScore").ToString()+" m";
        if(isEvent)
        {
            resume.onClick.AddListener(() => Restart());
        }
        else
        {
            resume.onClick.AddListener(() => Resume());
        }
    }
    void Restart()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        Application.LoadLevel("Gameplay");
        Score.score = 0;
    }
    void Resume()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
