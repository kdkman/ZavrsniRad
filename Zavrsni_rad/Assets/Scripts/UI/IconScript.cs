using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IconScript : MonoBehaviour 
{
    private Image img;


    public void OnEnter() {
        //TODO open player inevenotry
        print("Hey");
    }

    // Use this for initialization
    void Awake () {
        img = gameObject.GetComponent<Image>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
