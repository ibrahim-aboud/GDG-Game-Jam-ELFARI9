using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Essentials
    public Camera cam;
    CharacterController controller;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Movement
    Vector2 movement;
    public float walkSpeed;
    public float sprintSpeed;
    float trueSpeed;

    // Jumping
    public float jumpHeight;
    public float gravity;
    bool isGrounded;
    Vector3 velocity;
    private Animator animator;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootFrequency;
    private float lastShootTime = 0.1f;
    public float freezeTime;
    public float shootSpeed;
    public float shootDistance=10f;

    public float rotationSpeed = 3f;

    void Start()
    {
        trueSpeed = walkSpeed;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.SetInteger("state",0);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
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
    }
    else
    {
        animator.SetInteger("state", 0); // Set the state to idle
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
    
    // Shooting
        lastShootTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && lastShootTime >= freezeTime)
        {
            Debug.Log("The shot");
            Shoot();
            
        }
}

// public void Fire(Vector3 target)
//     {
//         if (lastShootTime < freezeTime)
//             return;
//         Vector3 dir = target - bulletPos.position;
//         Vector3 xyProject = Vector3.ProjectOnPlane(dir, Vector3.up);
//         if (num <= 0)
//             return;
//         Vector3 bulletStartPos = bulletPos.position;
//         bulletStartPos.y = 1;
//         GameObject g = (GameObject)GameObject.Instantiate(bullet, bulletStartPos, Quaternion.FromToRotation(Vector3.forward, xyProject.normalized));
//        num--;
//         lastShootTime = 0f;
//     }
// void Shoot()
// {
//     lastShootTime = 0f;

//     Ray ray = cam.ScreenPointToRay(Input.mousePosition);
//     RaycastHit hit;

//     if (Physics.Raycast(ray, out hit))
//     {
//         Vector3 targetPosition = hit.point;

//         GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
//         Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();

//         // Calculate the direction towards the target position
//         Vector3 direction = targetPosition - bulletSpawnPoint.position;
//         direction.Normalize();

//         bulletRigidbody.velocity = direction * shootSpeed;
//     }
// }
void Shoot()
{
    lastShootTime = 0f;

    Vector3 targetPosition = transform.position + transform.forward * shootDistance;

    GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();

    // Calculate the direction towards the target position
    Vector3 direction = targetPosition - bulletSpawnPoint.position;
    direction.Normalize();

    bulletRigidbody.velocity = direction * shootSpeed;
}

}

