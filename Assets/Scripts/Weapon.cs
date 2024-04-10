using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] Transform emission;
    [SerializeField] AudioSource audio;
	[SerializeField] TMP_Text text;
	[SerializeField] float balls = 20;

	void Update()
    {
        if (Input.GetMouseButtonDown(0) && balls > 0)
        {
            audio.Play();
            Instantiate(ammo, emission.position, emission.rotation); //uses our transform
            balls--;
            text.text = "Balls: " + balls;
        }
    }
}
