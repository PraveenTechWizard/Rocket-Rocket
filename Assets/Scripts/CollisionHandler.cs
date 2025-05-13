using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //Variables for particle effects
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    //Checking if object hit or not 
    //Boolean Variables
    bool isNotHiting = true;

    //Variable for particle object
    //ParticleSystem particleObject;

    // Start is called before the first frame update
    //void Start()
    //{
    //    //Get the Particle System component attached to the GameObject
    //    particleObject = GetComponent<ParticleSystem>();
    //}
    private void OnCollisionEnter(Collision collisionObject)
    {
        //Condition for unwanted collision
        if (!isNotHiting) { return; } // If isNotHiting is false, exit the function

        //Check if the object is collided with the Starting Point, Ending Point, or Obstacle
        switch (collisionObject.gameObject.tag)
            {
            //Conditon for unwanted collision
                case "StartingPoint":
                    break;
                case "EndingPoint": // This is the Ending Point                                       
                        isNotHiting = false; // Set isNotHiting to false to prevent further collisions
                        MoveON(); // Call the MoveON function                   
                    break;
                    
                default: // This is the Obstacle                    
                        isNotHiting = false; // Set isNotHiting to false to prevent further collisions
                        PlayerReload(); // Disable the Active on Object and Reload the Same Level                    
                    break;
            }
            
    }

    //This function is called when the object is collided with the Ending Point Player will go to Next Level
    private void MoveON()
    {
        GetComponent<Movements>().DisableAudio(); // Stop the audio source from Movement script (thruster)
        //Play the success particle effect
        ParticleSystem successVfx =  Instantiate(successParticle, transform.position, Quaternion.identity); //Set variable
        successVfx.Play(); // Instantiate the success particle effect at the object's position
        Destroy(successVfx.gameObject, 3f); // Destroy the particle effect after 2 seconds

        GetComponent<Movements>().enabled = false; // Disable the Movements script
        Invoke("NextLevel", 4f); // Delay for 1 second before calling NextLevel
    }

    //This function is called when the object is collided with Obstacle Player Reload
    private void PlayerReload()
    {

        //Play the crash particle effect
        ParticleSystem crashVfx =  Instantiate(crashParticle, transform.position, Quaternion.identity); //Set variable
        crashVfx.Play();
        Destroy(crashVfx.gameObject, 2f); // Destroy the particle effect after 2 seconds

        GetComponent<Movements>().DisableAudio(); // Stop the audio source from Movement script (thruster)
        GetComponent<Movements>().enabled = false; // Disable the Movements script
        Invoke("ReloadLevel", 2); // Delay for 1 second before calling ReloadLevel
    }

    //This function is called when the object is collided with the Ending Point Player Go to Next Level
    private void NextLevel()
    {
        //Get the current scene index and increment it to load the next scene
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Increment the scene index to load the next scene (Variable)
        int nextScene = nextSceneIndex + 1;

        // Check if the next scene index is within the valid range
        if (nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            // If the next scene index is out of range, loop back to the first scene
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }

    // This function is called when the object is destroyed (HIT)
    private void ReloadLevel()
    {        
        //particleObject.Play(crashParticle); // Play the crash particle effect
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
   
}
