using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private string _scorePrefix = "Score: ";
    public Text scoreText;
    public int score;

    public void incrementScore() {
        scoreText.text = _scorePrefix + ++score;
    }
}