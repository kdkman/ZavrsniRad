using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class ShopKeeprAnimation : MonoBehaviour {

    private Animator anim;
    private Canvas ui;
    private GameObject self;
    private Transform playerTrasform;
    private float dist;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))//on click
        {
            if(dist < 5f) { 
            ui.enabled = true;
            anim.SetInteger("go", 0);// puting hmm aniation
            }
        
        }

    }
    

    // Use this for initialization
    void Awake () {
        ui = gameObject.GetComponentInChildren<Canvas>();

        anim = GetComponent<Animator>();
        ui.enabled = false;

        playerTrasform = GameObject.Find("Player").GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(playerTrasform.position, gameObject.transform.position);

        if (dist > 5f) { ui.enabled = false; }

         if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hmm"))
            {

                anim.SetInteger("go", 1);
            }
        

    }
}
