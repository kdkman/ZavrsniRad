using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterAnimator : MonoBehaviour {

    private const float locomotionAnimatorSmoothTime = 0.1f;
    private float startTime = 0f;
    Animator animator;
    NavMeshAgent agent;

    CameraRoation camScriptRef;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        camScriptRef = Camera.main.GetComponent<CameraRoation>();

    }
	
	// Update is called once per frame
	void Update () {


        AnimationForMovemnt(agent.isStopped);


    }

    private void AnimationForMovemnt(bool stopped)
    {
        float speedPercent=0;
        if (!stopped)//Navagaiton animation part #Perfect 
        {
            speedPercent = agent.velocity.magnitude / agent.speed;//takeing speed % form current speed / max speed
            animator.SetFloat("speedPercent", speedPercent, locomotionAnimatorSmoothTime, Time.deltaTime);//setting float on animation bleed tree // locomotionAnimatorSmoothTime is for smoothing
        }
        else//WASD animation part  90%-perfect
        {
            if (startTime == 0)
            {
                startTime = Time.time;
            }

        
            speedPercent =((camScriptRef.zRefrence*10f )/2+0.2f);  // zRef (from 0.01 to 0.2)
           
            if (camScriptRef.zRefrence < 0.009)
            {
                speedPercent = 0;
            }

            animator.SetFloat("speedPercent", speedPercent, locomotionAnimatorSmoothTime, Time.deltaTime);
        }

    }
}
