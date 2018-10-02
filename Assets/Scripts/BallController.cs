using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject particle; // Holds the particle to be instantiated

    [SerializeField]
    private float speed; // Use it in the velocity method
    bool started; // Use it to check if the game is started or not
    bool gameOver; // Use it to check if the game is over or not
    Rigidbody rb; // Instance of the Rigidbody

    // Runs before Start() called just before entering the scene
    void Awake () {
        rb = GetComponent<Rigidbody> ();
    }

	// Use this for initialization, called when entering in the scene
	void Start () {
        started = false; // Initially the game is not started
        gameOver = false; // Initially the game is not over
    }
	
	// Update is called once per frame
	void Update () {

        // If our game is not started 
        if (!started) {

            // if the mouse is clicked
            if (Input.GetMouseButtonDown (0)) {

                // Add a velocity to the ball
                rb.velocity = new Vector3 (speed, 0, 0);

                // Get the game started
                started = true;
                GameManager.instance.StartGame ();
            }
        }

        // Check from which position we are casting the ray
        Debug.DrawRay (transform.position, Vector3.down, Color.red);

        // Check if Ray is colliding with any gameObejct
        // if it is not colliding
        if ( ! Physics.Raycast (transform.position, Vector3.down, 1f)) {

            // game should be over
            gameOver = true;

            // Change the velocity of the ball and make it fall down in a high velocity
            rb.velocity = new Vector3 (0, -25f, 0);

            // Set the game over in the camera to be true
            Camera.main.GetComponent<CameraFollow> ().gameOver = true;

            GameManager.instance.GameOver ();
        }

        // Whenever we click our mouse button and game is not over, SwitchDirection() function should be called
        // if (Mouse button is pressed and game is not over)
        if (Input.GetMouseButtonDown (0) && !gameOver) {

            // call the SwitchDirection() function
            SwitchDirection ();
        }
	}

    void SwitchDirection () {

        // if the ball has speed in z direction
        if (rb.velocity.z > 0) {

            // z velocity 0 and x velocity speed
            rb.velocity = new Vector3 (speed, 0, 0);
            
        }

        // if the ball has speed in x direction
        else if (rb.velocity.x > 0) {

            // x velocity 0 and z velocity speed
            rb.velocity = new Vector3 (0, 0, speed);
            
        }
    }

    // This function gets called by Unity when the ball enters any trigger
    void OnTriggerEnter (Collider col) {

        // if the object is diamond
        if (col.gameObject.tag == "Diamond") {

            // Instantiate the particle system in the temporary variable
            GameObject part = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;

            // Destroy that diamond
            Destroy (col.gameObject);

            // Destroy the particle effect
            Destroy (part, 1f);
        }
    }
}
