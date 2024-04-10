using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : MonoBehaviour
{
    [SerializeField] Aim player;
    [SerializeField] AudioSource hitAudio;
    [SerializeField] AudioSource pointsAudio;
    [SerializeField] TMP_Text text;

    Rigidbody rb;
    bool destroyed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (rb.velocity.magnitude > 2 || rb.angularVelocity.magnitude > 2)
        {
			hitAudio.Play();
		}
    }

	private void OnTriggerStay(Collider other)
	{
        if (!destroyed && other.CompareTag("Kill") && rb.velocity.magnitude == 0 && rb.angularVelocity.magnitude == 0)
        {
            destroyed = true;
            player.points += 100;
            pointsAudio.Play();
			Destroy(gameObject, 1);
        }
	}

	private void OnGUI()
	{
        if (destroyed)
        {
			GUI.skin.label.fontSize = 50;
            GUI.color = Color.green;
			Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);

			GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), "+" + 100); //Screen.width/2
            text.text = "Score:" + player.points;
		}
	}
}
