using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhunMove : MonoBehaviour
{
	[SerializeField] Transform transform;
	bool clicked = false;
	private void OnTriggerEnter(Collider other)
	{
		clicked = true;
	}

	private void Update()
	{
		if (clicked)
		{
			transform.position += (Vector3.down * 2 * Time.deltaTime);
		}
	}
}
