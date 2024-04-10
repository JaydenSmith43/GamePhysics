using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField] Aim player;
	[SerializeField] AudioSource pointsAudio;
	[SerializeField] TMP_Text text;

	bool destroyed = false;

	private void OnCollisionEnter(Collision collision)
	{
		player.points += 200;
		destroyed = true;
		pointsAudio.Play();
		Destroy(gameObject, 1);
	}

	private void OnGUI()
	{
		if (destroyed)
		{
			GUI.skin.label.fontSize = 50;
			GUI.color = Color.green;
			Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);

			GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), "+" + 200); //Screen.width/2
			text.text = "Score:" + player.points;
		}
	}
}
