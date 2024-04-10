using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhunButton : MonoBehaviour
{
	[SerializeField] GameObject prefab;
	[SerializeField] Transform spawnLocation;

	private void OnTriggerEnter(Collider other)
	{
		Instantiate(prefab, spawnLocation.position, transform.rotation);
		print("Click!");
	}
}
