using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ShopKeeprAnimation : MonoBehaviour {

    Animator anim;

    private void OnMouseDown()
    {
 
        anim.SetInteger("go", 0);// puting hmm aniation

    }

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

       
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hmm"))
            {

                anim.SetInteger("go", 1);
            }
        

    }
}
