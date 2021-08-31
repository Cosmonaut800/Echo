using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
	public Animator animator;
	public Transform cam;
    public float speed = 6.0f;
	public float gravity = -10.0f;
	public float turnSmoothTime = 0.1f;
	public Transform groundCheck;
	public float groundDistance;
	public LayerMask groundMask;

	private float turnSmoothVelocity;
	private bool isGrounded = false;
	private bool isMoving;
	private Vector3 velocity = Vector3.zero;
	private bool moveLock = false;
	private bool stompLock = false;

	// Start is called before the first frame update
	void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;

        if ((isMoving = direction.magnitude >= 0.1f) && CheckMoveCondition())
        {
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

			Vector3 moveDir = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
			controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		velocity.y += gravity * Time.deltaTime;

		if(isGrounded)
		{
			velocity.y = -5.0f;
		}

		if (moveLock) isMoving = false;
		animator.SetBool("isMoving", isMoving);
		if (Input.GetButtonDown("Fire1") && !stompLock) animator.SetTrigger("stomp");

		controller.Move(velocity * Time.deltaTime);
    }

	public bool getIsMoving()
	{
		return isMoving;
	}

	public void DoDamage(Vector3 position, float range)
	{
		if (Vector3.Distance(transform.position, position) < range)
		{
			animator.SetTrigger("damage");
		}
	}

	public bool CheckMoveCondition()
	{
		return !animator.GetCurrentAnimatorStateInfo(0).IsName("Stomp") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Loot") && !moveLock;
	}

	public void LockMovement(bool value)
	{
		moveLock = value;
	}

	public void LockStomp(bool value)
	{
		stompLock = value;
	}
}
