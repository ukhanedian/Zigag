using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ball; // Assign it which GameObject to follow in the Unity editor
    Vector3 offset; // Displacement between the camera and the ball
    public float lerpRate; // The rate by which camera will change its position to follow the ball
    public bool gameOver;

	// Use this for initialization
	void Start () {

        // Assigning the distance in offset and this distance should always be the same
        offset = ball.transform.position - transform.position; // ball's position - camera's position

        gameOver = false; // Initially the game is not over
	}
	
	// Update is called once per frame
	void Update () {

		// if game is not over 
        if (! gameOver) {

            // Follow every frame
            Follow ();
        }
	}

    void Follow() {

        Vector3 pos = transform.position; // temporary variable to store the position of the camera
        Vector3 targetPos = ball.transform.position - offset; // temporary variable to store the position to achieve (ball's position - offset)
        
        // Lerp the current value to the target value with the lerpRate
        pos = Vector3.Lerp (pos, targetPos, lerpRate * Time.deltaTime);

        // Assign temporary position value to original position (transform.position)
        transform.position = pos;
    }
}
