using System;
using UnityEngine;

public class CameraDragBehavior : MonoBehaviour
{
	[SerializeField] private Camera cam;
	private Vector3 ResetCamera;
	private Vector3 Origin;
	private Vector3 Diference;
	private bool Drag=false;
	private int CameraSpeed=15;
	void Start () {
		ResetCamera = cam.transform.position;
	}
	void LateUpdate () {
		// Drag Camera on mouse click
		if (Input.GetMouseButton (0)) {
			Diference=(cam.ScreenToWorldPoint (Input.mousePosition))- cam.transform.position;
			if (Drag==false){
				Drag=true;
				Origin=cam.ScreenToWorldPoint (Input.mousePosition);
			}
		} else {
			Drag=false;	
		}
		if (Drag==true){
			cam.transform.position = Origin-Diference;
		}

		// move camera on WASD/arrow key input
		float x = Input.GetAxis("Horizontal") * CameraSpeed * Time.deltaTime;
		float y = Input.GetAxis("Vertical") * CameraSpeed * Time.deltaTime;

		transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
		
		float scrollY = Input.mouseScrollDelta.y;

		if (scrollY != 0f)
		{
			float newSize = cam.orthographicSize - (scrollY);
			
			cam.orthographicSize = Mathf.Clamp(newSize, 1, 20);
			
		}
	}   
}
