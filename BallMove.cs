using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private bool InverseControl;
    [SerializeField] private float Speed;
    [SerializeField] private float maxInputValue;
    [SerializeField] private float gravityForce;
    
    private Vector3 velocity;
    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Max speed by gravity
        rb.maxAngularVelocity = 100;
    }

    void Update()
    {
        //Inputs with inverse
        horizontalInput = InverseControl ? Input.GetAxis("Mouse X") *-1 : Input.GetAxis("Mouse X");
        verticalInput = InverseControl ? Input.GetAxis("Mouse Y") * -1 : Input.GetAxis("Mouse Y");

        //Input limit control
        if (horizontalInput > maxInputValue) horizontalInput = maxInputValue;
        if (verticalInput > maxInputValue) verticalInput = maxInputValue;

        //Move
        Vector3 translation = verticalInput * Camera.transform.forward;
        translation += horizontalInput * Camera.transform.right;
        translation.y = 0;

        if (translation.magnitude > 0) velocity = translation;
        else velocity = Vector3.zero;

        rb.AddForce(velocity * Speed);
        rb.AddForce(0, gravityForce, 0);
    }
}