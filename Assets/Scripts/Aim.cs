using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Aim : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] public float points = 0;
    [SerializeField] AudioSource audio;

    Vector3 rotation = Vector3.zero;
    Vector2 prevAxis = Vector2.zero;

    bool moving = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

		prevAxis.x = -Input.GetAxis("Mouse Y");
		prevAxis.y = Input.GetAxis("Mouse X");
	}

    void Update()
    {
        Vector3 axis = Vector3.zero;
        axis.x = -Input.GetAxis("Mouse Y") - prevAxis.x;
        axis.y = Input.GetAxis("Mouse X") - prevAxis.y;

        rotation.x += axis.x * speed;
        rotation.y += axis.y * speed;

		//rotation.x = Mathf.Clamp(rotation.x, -50, 50);
		//rotation.y = Mathf.Clamp(rotation.y, -50, 50);

		Quaternion qyaw = Quaternion.AngleAxis(rotation.y, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(rotation.x, Vector3.right);

        transform.localRotation = (qyaw * qpitch);

        Vector3 target = Vector3.zero;

        if (Input.GetAxis("Horizontal") != 0)
        {
			transform.RotateAround(target, Vector3.up, -Input.GetAxis("Horizontal") * 30 * Time.deltaTime);
            moving = true;
		}
        else
        {
			moving = false;
			audio.volume = 0;
            audio.Stop();
            //audio.
		}

        if (moving)
        {
            if (!audio.isPlaying)
            {
				audio.Play();
				audio.volume = 100;
			}

		}
		
	}
}
