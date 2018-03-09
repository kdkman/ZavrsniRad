using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MarketUI : MonoBehaviour {

    [HideInInspector]
    public bool UIhit;


    private Text name;

    // Use this for initialization
    void Awake () {
        name = gameObject.GetComponentInChildren<Text>(); //getting textbox 
        name.text = transform.parent.name; // seting name of textbox
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
