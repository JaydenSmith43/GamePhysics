using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
	[SerializeField, Range(1, 100)] float speed = 3;
	[SerializeField, Range(1, 100)] float jumpHeight = 2;
	[SerializeField, Range(1, 100)] float pushPower = 2;
	[SerializeField, Range(1, 100)] float rotationRate = 3;
	[SerializeField] Transform view;
	[SerializeField] Animator animator;

	private CharacterController controller;
	private Vector3 velocity;
	private bool groundedPlayer;

	private void Start()
	{
		controller = gameObject.GetComponent<CharacterController>();
	}

	void Update()
	{
		groundedPlayer = controller.isGrounded;
		if (groundedPlayer && velocity.y < 0)
		{
			velocity.y = 0f;
		}

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		move = Vector3.ClampMagnitude(move, 1);

		// view space
		move = Quaternion.Euler(0, view.rotation.eulerAngles.y, 0) * move;


		controller.Move(move * Time.deltaTime * speed);

		if (move != Vector3.zero)
		{
			//gameObject.transform.forward = move;
			gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * rotationRate); //spherical lerp
		}

		// Changes the height position of the player..
		if (Input.GetButton("Jump") && groundedPlayer)
		{
			velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity.y); //gravityValue = -9.81f
		}

		velocity.y += Physics.gravity.y * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

		animator.SetFloat("Speed", move.magnitude * speed);
		animator.SetFloat("YVelocity", velocity.y);
		animator.SetBool("OnGround", groundedPlayer);
	}

	// this script pushes all rigidbodies that the character touches
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;

		// no rigidbody
		if (body == null || body.isKinematic)
		{
			return;
		}

		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3)
		{
			return;
		}

		// Calculate push direction from move direction,
		// we only push objects to the sides never up and down
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

		// If you know how fast your character is trying to move,
		// then you can also multiply the push velocity by that.

		// Apply the push
		//body.AddForce(pushDir * pushPower, ForceMode.VelocityChange) //also works
		body.velocity = pushDir * pushPower;
	}
}
