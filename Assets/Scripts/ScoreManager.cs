using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    // Create singleton instance of ScoreManager
    public static ScoreManager instance;

    // Create public score variables
    public int score;
    public int highscore;

    void Awake () {

        if (instance == null) {

            instance = this;
        }
    }

	// Use this for initialization
	void Start () {

        score = 0;

        // saves the score and highscore in our machine
        PlayerPrefs.SetInt ("score", score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void incrementScore () {

        score += 1;
    }

    public void startScore () { // calls the incrementScore() function

        InvokeRepeating ("incrementScore", 0.1f, 0.5f);
        //incrementScore ();
    }

    public void stopScore () { // stops incrementing the score

        CancelInvoke ("incrementScore");

        // saves the score and highscore in our machine
        PlayerPrefs.SetInt ("score", score);

        // if we have highscore saved in our machine
        if (PlayerPrefs.HasKey ("highScore")) {
            // then if our is greater than previous highscore
            if (score > PlayerPrefs.GetInt ("highScore")) {
                // Set the highscore to the current score
                PlayerPrefs.SetInt ("highScore", score);
            }
        } else { // otherwise

            // Save our score to highscore
            PlayerPrefs.SetInt ("highScore", score);
        }
    }
}
