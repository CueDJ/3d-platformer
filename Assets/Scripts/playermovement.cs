using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] private float speed; // Speed multiplier
    [SerializeField] private float jumpForce; // Jump force multiplier
    private Rigidbody rb; // Rigidbody component cache
    private Vector3 moveDirection; // Stores the direction of movement
    public Transform orientation; // Stores the orientation of the player
    private float verticalInput;
    private float horizontalInput;
    private float jumpInput;
    private Camera cam;

    private bool isGrounded;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        cam = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Inputs();
        UpdateCamPos();
        cam.gameObject.GetComponent<PlayerRotation>().CameraRotation();
        RotateToCam();
        CheckIfGrounded();
    }
    private void FixedUpdate()
    {
        Movement();

    }
    private void Inputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetAxisRaw("Jump");
    }
    private void Movement()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection * speed, ForceMode.Force);
        if (jumpInput > 0 && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void RotateToCam()
    {
        transform.rotation = Quaternion.Euler(0f, cam.transform.rotation.eulerAngles.y, 0f);
    }
    private void CheckIfGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit raycast, 1.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void UpdateCamPos()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
    }
}

