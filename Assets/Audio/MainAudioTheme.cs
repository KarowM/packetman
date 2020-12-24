using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioTheme : MonoBehaviour {

    private static MainAudioTheme instance = null;

    public static MainAudioTheme Instance {
        get { return instance;  }
    }
    void Awake()
    {
        if (instance !=null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
