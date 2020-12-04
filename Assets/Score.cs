using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private string _scorePrefix = "Score: ";
    public Text scoreText;
    public int score;

    void Start() {
    }

    void Update() {
        scoreText.text = _scorePrefix + score;
    }

    public void incrementScore() {
        score++;
    }
}