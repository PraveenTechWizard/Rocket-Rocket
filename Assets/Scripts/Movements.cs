using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    //Assign Variable
    [SerializeField] InputAction thruster;
    [SerializeField] InputAction rotation;
    [SerializeField] InputAction restart;

    Rigidbody rb;

    //Assessable Variables
    [SerializeField] float thrusterSpeed = 100f;
    [SerializeField] float rotationSpeed = 5f;


    //
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        thruster.Enable();
        rotation.Enable();
        restart.Enable();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
        RestartPosition();
    }

    private void ProcessThrust()
    {
        if (thruster.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrusterSpeed * Time.fixedDeltaTime);
           
        }
    }

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

    private void ApplyRotation(float rotationValue)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationValue * Time.fixedDeltaTime);
        rb.freezeRotation = false;
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
}
