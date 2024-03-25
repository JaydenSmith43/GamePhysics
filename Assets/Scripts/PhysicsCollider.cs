using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
	string status;

	private void OnCollisionEnter(Collision collision)
	{
		status = "collision enter: " + collision.gameObject.name;
	}

	private void OnCollisionStay(Collision collision)
	{

	}

	private void OnCollisionExit(Collision collision)
	{

	}

	private void OnTriggerEnter(Collider collision)
	{
		status = "trigger enter: " + collision.gameObject.name;
	}

	private void OnTriggerStay(Collider other)
	{
		
	}

	private void OnTriggerExit(Collider other)
	{
		
	}

	private void OnGUI()
	{
		GUI.skin.label.fontSize = 16;
		Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);

		GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status); //Screen.width/2
	}
}
