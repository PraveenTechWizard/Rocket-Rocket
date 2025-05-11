using System;
using UnityEngine;

public class Audios : MonoBehaviour
{
    //Assign Variable(for get audio clip)
    [SerializeField] AudioClip explosionSound, successSound ;

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
        switch(collisionObject.gameObject.tag)
        {
            //Play Starting Sound Effect
            case "StartingPoint":
                //Play Starting Sound Effect
                break;

            //Play Wining Sound Effect
            case "EndingPoint":
                //Play Wind Sound Effect
                audioSource.PlayOneShot(successSound);
                break;
          
            //Play Explosion Sound Effect
            default:
                //Play Explosion Sound Effect
                audioSource.PlayOneShot(explosionSound);
                break;
        }
    }

}
