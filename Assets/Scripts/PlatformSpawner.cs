using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform; // Our first platform that we want to spawn
    public GameObject diamonds; // Our diamonds that we want to spawn

    Vector3 lastPos; // The position where our last platform was
    float size; // Size of the plaform
    public bool gameOver; // Checks if the game is over

	// Use this for initialization
	void Start () {

        // Calculate the last position as the position of the platform
        lastPos = platform.transform.position;

        size = platform.transform.localScale.x;

        for(int i = 0 ; i < 20 ; i++) { SpawnPlatforms (); }
	}

    public void StartSpawningPlatforms () {

        // Spawn the platforms repeatedly at certain rate
        InvokeRepeating ("SpawnPlatforms", 0.1f, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {

        if (GameManager.instance.gameOver == true) {
                
            // It is the opposite of Invoke or InvokeRepeating
            CancelInvoke ("SpawnPlatforms");
        }
    }

    void SpawnPlatforms () {

        // Check if we have to create the new platform in the x direction or z direction
        int range = Random.Range (0, 6); // Generate random numbers between two ranges

        // if we have to create the new platform in the x direction
        if (range >= 0 && range <= 2) {
            SpawnX ();
        } else

        // if we have to create the new platform in the x direction
        if (range >= 3 && range <= 5) {
            SpawnZ ();
        }
    }

    void SpawnX () { // Spawns the platform in the x direction

        Vector3 pos = lastPos; // Temporary variable to store the last position of the platform

        // Change the position in the x direction to the size of original platform
        pos.x += size;
        
        lastPos = pos; // Update the position

        // Instatntiate the platform at that position
        Instantiate (platform, pos, Quaternion.identity);

        // Generate a random number 
        int rand = Random.Range (0, 4);

        // Check when to instantiate diamonds
        if (rand < 1) {

            // Instantiate the diamonds
            Instantiate (diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
    }

    void SpawnZ () { // Spawns the platform in the z direction

        Vector3 pos = lastPos; // Temporary variable to store the last position of the platform

        // Change the position in the z direction to the size of original platform
        pos.z += size;

        lastPos = pos; // Update the position

        // Instatntiate the platform at that position
        Instantiate (platform, pos, Quaternion.identity);

        // Generate a random number 
        int rand = Random.Range (0, 4);

        // Check when to instantiate diamonds
        if (rand < 1) {

            // Instantiate the diamonds
            Instantiate (diamonds, new Vector3 (pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
    }
}
