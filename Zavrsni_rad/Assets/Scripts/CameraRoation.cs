using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CameraRoation : MonoBehaviour {

	private const float Y_Angle_MIN = 0f;//min look angle
	private const float Y_Angle_MAX= 50f;//max look angle

	private const float Y_CamDistance_MIN = 8f;//min look Camera distance
	private const float Y_CamDistance_MAX= 15f;//max look aCamera distance

	public Transform lookAt;// What camera looks at	
	public Transform camTransform;//Camera transform

	private Camera cam;//Main camera

	private float distance =10f;
	private float currentX=0f;
	private float currentY=0f;
	private float sesivityX=4f;
	private float sesivityY=1f;

	private Vector2 mouseScroll;

    private NavMeshAgent agent;
    private GameObject player;

    [HideInInspector]
    public float zRefrence;
 
	private void Awake()
	{
	
		camTransform = transform;
		cam = Camera.main;
        agent = GameObject.Find("Player").GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");

     

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

        PlayerMove_PnC();
        PlayerMove_WASD();
        
      

    }

	private void LateUpdate()
	{
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);//angle where player is looking at
		camTransform.position = lookAt.position + rotation*dir;// putting camera behind the player by distance

        camTransform.LookAt(lookAt.position);//cam look at destiantion
        camTransform.position = new Vector3(camTransform.position.x, camTransform.position.y + 2, camTransform.position.z);

    }




    private void PlayerMove_WASD()// Player WASD movement  
    {  
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //TODO fix backword movemnt 
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;
        if (x != 0 || z != 0)
        {
            agent.Stop();
            player.transform.Rotate(0, x, 0);
            player.transform.Translate(0, 0, z);
            zRefrence = z;
        }
        if ((Input.GetKey(KeyCode.Mouse1)))// setting player rotation to camera rotation
        {
            if (Input.GetKey(KeyCode.W))
            {
                Quaternion rotation = camTransform.transform.rotation;
                rotation.x = 0f;
                rotation.z = 0f;
                player.transform.rotation = rotation;

            }
        }



        }

    private void PlayerMove_PnC()//Player Point and Click movement //works perfectly
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            agent.Resume();
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))//1000 is how far hit can be
            {
                if (hit.transform.gameObject == GameObject.Find("Market Kepper")) {
                    agent.Stop(); }
                else
                {
                    agent.destination = hit.point;
                }
               
            }
        }
    }
}


