using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] Transform emission;
    [SerializeField] AudioSource audioSource;
	[SerializeField] TMP_Text text;
	[SerializeField] float balls = 20;

	[SerializeField] public bool equipped = false;

	void Update()
    {
		Debug.DrawRay(emission.position, emission.forward * 10, Color.red);

		if (equipped && Input.GetMouseButtonDown(0))
		{
			if (audioSource != null) audioSource.Play();
			Instantiate(ammo, emission.position, emission.rotation);
		}

		//if (Input.GetMouseButtonDown(0) && balls > 0)
  //      {
  //          audio.Play();
  //          Instantiate(ammo, emission.position, emission.rotation); //uses our transform
  //          balls--;
  //          text.text = "Balls: " + balls;
  //      }
    }
}
