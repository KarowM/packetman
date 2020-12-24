using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class LifeManager : MonoBehaviour {

    [SerializeField] AudioClip deathClip;
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
    public void PlayerDeath(GameObject player) {
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position);
        Destroy(player);
        Destroy(lives[--numLives]);

        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene() {
        yield return new WaitForSeconds(1.5f);

        if (numLives > 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else {
            //TODO: go to fail scene
            Debug.Log("Out of Lives!!!");
        }
    }
}
