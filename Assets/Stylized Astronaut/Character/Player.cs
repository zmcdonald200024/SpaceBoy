/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {*/

	/*private Animator anim;
	private CharacterController controller;

	public float speed = 600.0f;
	public float jumpSpeed = 550.0f;
	public float turnSpeed = 400.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;



	void Start () {
		controller = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update (){



	if (Input.GetKey ("w")) {
			anim.SetInteger ("AnimationPar", 1);
		}
	else if (Input.GetKey("space")){
		anim.SetInteger ("JumpPar", 1);
	}
		else if(Input.GetKey("space") && Input.GetKey("w"))
	{
		anim.SetInteger("JumpPar", 2);
	}
	else {
			anim.SetInteger ("AnimationPar", 0);
		anim.SetInteger("JumpPar", 0);
		}


	if(controller.isGrounded){
	moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
	if (Input.GetButton("Jump"))
	moveDirection.y = jumpSpeed;
	}
	if (controller.isGrounded)
	{
		if (Input.GetKeyDown(KeyCode.Space))
			moveDirection.y = 10f;

		moveDirection = transform.forward * Input.GetAxis("Vertical") * speed + Vector3.up * moveDirection.y;
	}

	float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
	}

*/
	using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public CharacterController controller;
	public Transform cam;

	public float speed = 6;
	public float gravity = -9.81f;
	public float jumpHeight = 3;
	Vector3 velocity;
	bool isGrounded;
	private Animator anim;

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	float turnSmoothVelocity;
	public float turnSmoothTime = 0.1f;

	private AudioSource source;
	
	public int score = 0;
	public Transform NextLevelPoint;
	public Transform PlayerTr;




	private void Start()
    {
		anim = gameObject.GetComponentInChildren<Animator>();
		source = GetComponent<AudioSource>();
		

	}
	// Update is called once per frame
	void Update()
	{


		//jump
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
		}
		//gravity
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
		//walk
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

		if (direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(moveDir.normalized * speed * Time.deltaTime);
		}

		//ANIMATIONS
		if (Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetInteger("AnimationPar", 2);

			return;
		}

		if (Input.GetKey(KeyCode.W))
		{
			anim.SetInteger("AnimationPar", 1);

			return;
		}


		else
		{

			anim.SetInteger("AnimationPar", 0);

		}
	}
	



	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Coin"))
		{
			Destroy(collider.gameObject);

			score = score + 1;

			source.Play();
			PlayerPrefs.SetInt("Score", score);
			//THISSSS
			//PlayerPrefs.SetFloat("Score:", score);
			//SCORE WAS IN PARENTHESIS INSTEAD OF PP.GETINT(SCORE)
			
			UIEventController.Instance.UpdateScore(score);


		}
		if (collider.gameObject.CompareTag("Level2"))
		{


			PlayerTr.transform.position = NextLevelPoint.transform.position;


		}


		if (collider.gameObject.CompareTag("Victory"))
		{

			SceneManager.LoadScene("VictoryScene");
			//THISSSSSS
			PlayerPrefs.SetInt("Score", score);
			
			PlayerPrefs.Save();
			
		}
	}
}

	
	

