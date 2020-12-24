using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LifeManager : MonoBehaviour {

    private GameObject[] lives;
    private int numLives;

    private void Awake() {
        if (FindObjectsOfType<LifeManager>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        numLives = 3;
        lives = new GameObject[numLives];
        lives[0] = GameObject.Find("Life 1");
        lives[1] = GameObject.Find("Life 2");
        lives[2] = GameObject.Find("Life 3");
    }
    public void PlayerDeath() {
        if (numLives > 0) {
            Destroy(lives[--numLives]);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else {
            //TODO: go to fail screen
            Debug.Log("Out of Lives!!!");
        }
    }
}
