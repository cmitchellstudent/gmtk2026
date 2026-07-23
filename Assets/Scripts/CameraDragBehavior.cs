using System;
using UnityEngine;

public class CameraDragBehavior : MonoBehaviour
{
 private Vector3 ResetCamera;
	private Vector3 Origin;
	private Vector3 Diference;
	private bool Drag=false;
	private int CameraSpeed=15;
	void Start () {
		ResetCamera = Camera.main.transform.position;
	}
	void LateUpdate () {
		// Drag Camera on mouse click
		if (Input.GetMouseButton (0)) {
			Diference=(Camera.main.ScreenToWorldPoint (Input.mousePosition))- Camera.main.transform.position;
			if (Drag==false){
				Drag=true;
				Origin=Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
		} else {
			Drag=false;	
		}
		if (Drag==true){
			Camera.main.transform.position = Origin-Diference;
		}

		// move camera on WASD/arrow key input
		float x = Input.GetAxis("Horizontal") * CameraSpeed * Time.deltaTime;
		float y = Input.GetAxis("Vertical") * CameraSpeed * Time.deltaTime;

		transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);

	}   
}
