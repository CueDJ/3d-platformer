using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private float speed; // Speed multiplier
    private Rigidbody rb; // Rigidbody component cache
    private Vector3 moveDirection; // Stores the direction of movement
    public Transform orientation; // Stores the orientation of the player
    private float verticalInput;
    private float horizontalInput;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Inputs();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Inputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void Movement()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection * speed, ForceMode.Force);
    }
}

