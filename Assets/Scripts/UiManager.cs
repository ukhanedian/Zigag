using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for any kind of Ui elements reference
using UnityEngine.SceneManagement; // for scene managements like reloading the scene in this game

public class UiManager : MonoBehaviour {

    // static instance of Ui Manager, a singleton pattern;
    public static UiManager instance;

    // References to Ui objects to activated or deactivated
    public GameObject zigzagPanel; // set its animation
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1;
    public Text highScore2;

    void Awake () { // Used to set up everything for your game

        if (instance == null) {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {

        highScore1.text = "High Score: " + PlayerPrefs.GetInt ("highScore").ToString ();
    }

    // public functions
    public void GameStart () {

        tapText.SetActive (false); // disabling the tapText animation

        // play the animation of the Zigzag panel
        zigzagPanel.GetComponent<Animator> ().Play ("PanelUp");
    }

	public void GameOver () {

        // store the score and highscore
        score.text = PlayerPrefs.GetInt ("score").ToString();
        highScore2.text = PlayerPrefs.GetInt ("highScore").ToString();

        // enable the gameOver animation
        gameOverPanel.SetActive (true);

        // play the animation
        //zigzagPanel.GetComponent<Animator> ().Play ("gameOverPanelAppear");
    }

    public void Reset () { // Reloads the game from the beginning

        SceneManager.LoadScene (0);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
