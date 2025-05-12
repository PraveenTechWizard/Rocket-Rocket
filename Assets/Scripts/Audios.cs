using System;
using UnityEngine;

public class Audios : MonoBehaviour
{
    //Assign Variable(for get audio clip)
    [SerializeField] AudioClip explosionSound, successSound ;

    //Boolean Variables
    public bool isPlayable = true;

    //Object Variables
    AudioSource audioSource;


    private void Start()
    {
        //Get the Audio Source
        audioSource = GetComponent<AudioSource>();
        
    }

    //
    private void OnCollisionEnter(Collision collisionObject)
    {
        //Check if the object is non-controllable
        if (!isPlayable) { return; }

        //Check if the object is collided with the Starting Point, Ending Point, or Obstacle
        switch (collisionObject.gameObject.tag)
        {
            //Play Starting Sound Effect
            case "StartingPoint":
                //Play Starting Sound Effect
                break;

            //Play Wining Sound Effect
            case "EndingPoint":
                //Play Wind Sound Effect
                isPlayable = false; // Set isPlayable to false to prevent further collisions
                audioSource.PlayOneShot(successSound);
                break;
          
            //Play Explosion Sound Effect
            default:
                //Play Explosion Sound Effect
                isPlayable = false; // Set isPlayable to false to prevent further collisions
                audioSource.PlayOneShot(explosionSound, 0.2f);
                break;
        }
    }

}
