using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoation : MonoBehaviour {

	private const float Y_Angle_MIN = 5f;//min look angle
	private const float Y_Angle_MAX= 50f;//max look angle

	private const float Y_CamDistance_MIN = 5f;//min look Camera distance
	private const float Y_CamDistance_MAX= 30f;//max look aCamera distance

	public Transform lookAt;// What camera looks at	
	public Transform camTransform;//Camera transform

	private Camera cam;//Main camera

	private float distance =15f;
	private float currentX=0f;
	private float currentY=0f;
	private float sesivityX=4f;
	private float sesivityY=1f;

	private Vector2 mouseScroll;

	private void Awake()
	{
	
		camTransform = transform;
		cam = Camera.main;
	
	}

	private void Update(){
		mouseScroll = Input.mouseScrollDelta;
		if (Input.GetKey (KeyCode.Mouse1)) {
			currentX += Input.GetAxis ("Mouse X");
			currentY -= Input.GetAxis ("Mouse Y");

			currentY = Mathf.Clamp (currentY, Y_Angle_MIN, Y_Angle_MAX);//must be between 2 value 
		}
		distance += mouseScroll.y;
		distance = Mathf.Clamp (distance, Y_CamDistance_MIN, Y_CamDistance_MAX);//must be between 2 value 

	}

	private void LateUpdate()
	{
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);//angle where player is looking at
		camTransform.position = lookAt.position + rotation*dir;// putting camera behind the player by distance
		camTransform.LookAt(lookAt.position);
	}

	//TODO point and click
}
