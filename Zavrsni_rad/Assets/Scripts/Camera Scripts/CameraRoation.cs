using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class CameraRoation : MonoBehaviour {

    private const float Y_Angle_MIN = 0f;//min look angle
    private const float Y_Angle_MAX = 50f;//max look angle

    private const float Y_CamDistance_MIN = 8f;//min look Camera distance
    private const float Y_CamDistance_MAX = 15f;//max look aCamera distance

    public Transform lookAt;// What camera looks at	
    public Transform camTransform;//Camera transform

    private Camera cam;//Main camera
    public GameObject arrow;
    private GameObject arrowRef=null;
    private int numArrows=0;

    private float distance = 10f;
    private float currentX = 0f;
    private float currentY = 0f;
    private float sesivityX = 4f;
    private float sesivityY = 1f;

    private Vector2 mouseScroll;

    private NavMeshAgent agent;
    private GameObject player;
    private float playerArrowDist;

    private MarketUI marketUIRef;

    [HideInInspector]
    public float zRefrence;


    //setting refencse
    private void Awake()
    {

        camTransform = transform;
        cam = Camera.main;
        agent = GameObject.Find("Player").GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        marketUIRef = GameObject.Find("UI").GetComponent<MarketUI>();


    }

    /// <summary>
    /// Destory arrow refrences 
    /// ??? some magic around camera ???
    /// input for PnC and WASD
    /// </summary>
    private void Update() {
        if (arrowRef != null) { playerArrowDist = Vector3.Distance(player.transform.position, arrowRef.transform.position);}//if theres an arrow look for distance
        else { playerArrowDist = 5f; } // if there isnt set defualut 5f

        if (playerArrowDist < 1.6f) { Destroy(arrowRef);} //if the player is close to arrow destroy arrow

        mouseScroll = Input.mouseScrollDelta;//get scroll postion
        if (Input.GetKey(KeyCode.Mouse1)) {
            currentX += Input.GetAxis("Mouse X"); 
            currentY -= Input.GetAxis("Mouse Y");
            currentY = Mathf.Clamp(currentY, Y_Angle_MIN, Y_Angle_MAX);//must be between 2 value 
        }
        //somehow i need to i change the distance and then change camera angle ??

        distance += mouseScroll.y;
        distance = Mathf.Clamp(distance, Y_CamDistance_MIN, Y_CamDistance_MAX);//must be between 2 value 

        if (Input.GetMouseButtonDown(0)){ PlayerMove_PnC(); }
        PlayerMove_WASD();



    }

    //setts camera begind player
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);//angle where player is looking at
        camTransform.position = lookAt.position + rotation * dir;// putting camera behind the player by distance

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
            Destroy(arrowRef);
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

    private void PlayerMove_PnC()//Player Point and Click movement
    {
             agent.Resume(); 
            RaycastHit hitground;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitground, 1000))//1000 is how far hit can be
            {
                if (hitground.transform.gameObject.layer == 8) //if hitting NPCs on layer 8
                {
                    agent.Stop();
                    if (arrowRef != null) { Destroy(arrowRef); }
                }
                else
                {
                    if (arrowRef != null) { Destroy(arrowRef); }    //desotry old ref 
                    if (!IsPointerOverUIObject())
                    {
                        arrowRef = Instantiate(arrow);                  //add new object and ref to it 
                        agent.destination = hitground.point;
                        arrowRef.transform.position = hitground.point;
                    }
                }

            }
    }


    //looks for current event in this case mouse click if its over a UI it will return true
    private bool IsPointerOverUIObject() 
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);          //Get type of current event
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);  //take postion
        List<RaycastResult> results = new List<RaycastResult>();                                        //create list container
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);                              //puts current event raycast resulits in list
        return results.Count > 0;                                                                       //bool
    }


}


