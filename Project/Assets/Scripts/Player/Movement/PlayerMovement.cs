using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Interface to control the player. It is necessary to have an Animator
/// and a CharacterController2D script.
/// </summary>
public class PlayerMovement : MonoBehaviour {

	// Public attributes
	public float runSpeed = 40f;

	// Private attributes
	CharacterController2D controller;
	Animator animator;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public bool hurt = false;
	float hurtTime = 0f;


	// Start is called once at first frame
	void Start()
	{
		LoadData();

		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController2D>();
	}

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
            AudioManager.instance.Play("JumpSound");
            jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		if (Time.time > hurtTime + 0.25f)
		{
			IsHurt(false);

		}

	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}


	public void IsHurt(bool isHurt)
	{
		this.hurt = isHurt;
		hurtTime = Time.time;
		animator.SetBool("IsHurt", isHurt);
	}


	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}


	private void LoadData()
	{
		SettingsData data = new SettingsData();
		if(data != null)
		{
			runSpeed = data.playerSpeed;
		}
	}
}
