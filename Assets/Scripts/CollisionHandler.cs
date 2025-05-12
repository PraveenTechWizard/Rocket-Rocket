using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision collisionObject)
    {

            //Check if the object is collided with the Starting Point, Ending Point, or Obstacle
            switch (collisionObject.gameObject.tag)
            {
                case "StartingPoint":
                    break;
                case "EndingPoint": // This is the Ending Point

                    MoveON(); // Disable the Active on Object and Move to Next Level
                    break;
                default: // This is the Obstacle

                    PlayerReload(); // Disable the Active on Object and Reload the Same Level
                    break;
            }
            
    }

    //This function is called when the object is collided with the Ending Point Player will go to Next Level
    private void MoveON()
    {    
        GetComponent<Movements>().enabled = false; // Disable the Movements script
        Invoke("NextLevel", 4f); // Delay for 1 second before calling NextLevel
    }

    //This function is called when the object is collided with Obstacle Player Reload
    private void PlayerReload()
    {
        //Disable the Player
        GetComponent<Movements>().DisableAudio(); // Stop the audio source from Movement script (thruster)
        GetComponent<Movements>().enabled = false; // Disable the Movements script
        Invoke("ReloadLevel", 1f); // Delay for 1 second before calling ReloadLevel
    }

    //This function is called when the object is collided with the Ending Point Player Go to Next Level
    private void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScene = nextSceneIndex + 1;

        Debug.Log("Current Scene Index: " + nextSceneIndex); // Log the current scene index for debugging
        Debug.Log("Next Scene Index: " + nextScene); // Log the next scene index for debugging
        Debug.Log("Total Scenes in Build Settings: " + SceneManager.sceneCountInBuildSettings); // Log the total number of scenes in build settings
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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
   
}
