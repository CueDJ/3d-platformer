using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;
    private Vector3 moveDirection;
    public Transform orientation;
    private float verticalInput;
    private float horizontalInput;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Inputs()
    {

    }
    private void Movement()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection * speed, ForceMode.Force);
    }
}

