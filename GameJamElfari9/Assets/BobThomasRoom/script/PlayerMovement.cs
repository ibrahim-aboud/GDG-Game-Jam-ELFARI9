using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    CharacterController controller;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector2 movement;
    public float walkSpeed;
    public float sprintSpeed;
    float trueSpeed;

    public float jumpHeight;
    public float gravity;
    bool isGrounded;
    Vector3 velocity;
    private Animator animator;

    public float rotationSpeed = 3f;
    public AudioClip moveSoundClip; // Sound clip for player movement
    private AudioSource audioSource;

    void Start()
    {
        trueSpeed = walkSpeed;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.SetInteger("state", 0);
         // Create an AudioSource component if not already attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.loop = true;
        audioSource.clip = moveSoundClip;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(transform.position, .1f, 1);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -10;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            trueSpeed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            trueSpeed = walkSpeed;
        }

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float angle2 = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle2, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (trueSpeed == walkSpeed)
            {
                animator.SetInteger("state", 4);
            }
            else
            {
                animator.SetInteger("state", 5);
            }

            controller.Move(moveDirection.normalized * trueSpeed * Time.deltaTime);
             // Play move sound if not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            animator.SetInteger("state", 0); // Set the state to idle
            // Stop move sound if currently playing
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);
        }

        if (velocity.y > -20)
        {
            velocity.y += (gravity * 10) * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bug"))
        {
                    Debug.Log("collided with bug");

            SceneManager.LoadScene("StartClassScene");
        }
    }
}
