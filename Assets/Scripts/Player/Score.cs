using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    public static int score;

    private void Start()
    {
        StartCoroutine(ScoreText());
    }
    IEnumerator ScoreText()
    {
        yield return new WaitForSeconds(1);
        score++;
        scoreText.text = ""+score+" m";
        StartCoroutine(ScoreText());
    }
}
