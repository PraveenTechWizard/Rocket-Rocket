using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    //Assign Variable
    [SerializeField]  InputAction thruster;
    [SerializeField] InputAction rotation;
    [SerializeField] InputAction restart;

    //Audio Clips variables
    [SerializeField] AudioClip thrustSound;

    //Script Variables
    //Audios boolValue;

    //Object Variables
    Rigidbody rb;
    public AudioSource audioSource;

    //Assessable Variables
    [SerializeField] float thrusterSpeed = 100f;
    [SerializeField] float rotationSpeed = 5f;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //boolValue = GetComponent<Audios>();
    }

    // This function is called when the object is created
    private void OnEnable()
    {
        //Give the key enable to the Input Action
        thruster.Enable();
        rotation.Enable();
        restart.Enable();
      
    }

    private void FixedUpdate()
    {
        // This function is called Thruster and Sound Effect
        ProcessThrust();
        // This function is called for Rotation
        ProcessRotation();
        // This function is called for Restart Position
        RestartPosition();
    }

    private void ProcessThrust()
    {
       

        //Check the player press the thruster button (Up and sound effects)
        if (thruster.IsPressed())
        {
            //if thruster is pressed, we add a force to the object in the direction it is facing
            rb.AddRelativeForce(Vector3.up * thrusterSpeed * Time.fixedDeltaTime);

            //Play Sound
            if (thruster.IsInProgress() && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrustSound);
            }
        }
        else
        {
            //Stop Sound
            audioSource.Stop();
        }

    }

    //Rotation
    private void ProcessRotation()
    {
        float rotationValue = rotation.ReadValue<float>();
      
        //Condition
        if (rotationValue > 0)
        {
            ApplyRotation(-rotationSpeed);

        }
        else if (rotationValue < 0)
        {
            ApplyRotation(rotationSpeed);
            
        }
    }

    //Apply Rotation
    private void ApplyRotation(float rotationValue)
    {
        rb.freezeRotation = true; //we stop the physics system from rotating the object
        transform.Rotate(Vector3.forward * rotationValue * Time.fixedDeltaTime);
        rb.freezeRotation = false; // resume physics system
    }

    //Restart Position
    private void RestartPosition()
    {
        if (restart.IsPressed())
        {
            transform.position = new Vector3 (-5.178648f, 0.9587119f, -6.441f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    //Stop the Audio form Collision Script
    public void DisableAudio()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            //Debug.Log("Audio Stopped");
        }

    }
}
