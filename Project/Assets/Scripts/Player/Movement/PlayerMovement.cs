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


	// Start is called once at first frame
	void Start()
	{
		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController2D>();
	}

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
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

	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
