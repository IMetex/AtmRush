using UnityEngine;
public class CharacterMoveController : MonoBehaviour
{
    //public ParticleSystem deadPartical;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotationSpeed;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator animator;
    private NextLevel nextLevel;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        nextLevel = FindObjectOfType<NextLevel>();
    }
    void Update()
    {
        if (nextLevel.isMovingStop == false)
        {
            MoveThePlayer();
        }
    }
    void MoveThePlayer()
    {
        if (controller.isGrounded)
        {
            // Get the horizontal and vertical inputs from the player
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Calculate the movement direction based on the input
            moveDirection = new Vector3(horizontal, 0, vertical);
            moveDirection.Normalize();
            transform.Translate(moveDirection * speed * Time.deltaTime);
            moveDirection *= speed;
            //moveDirection = transform.TransformDirection(moveDirection);

            //Animations and Rotation
            if (moveDirection != Vector3.zero)
            {
                //Walk
                animator.SetBool("IsMoving", true);

                // Rotation character 
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                //Idle
                animator.SetBool("IsMoving", false);
            }

            // Jump if the player presses the Jump button
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        // Apply gravity to the movement direction
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the character controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}

