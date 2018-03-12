using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TMPro.Examples
{
    //TODO FIX UI
    public class Tooltip : MonoBehaviour
    {

        private Item item;
        private string data;
        public GameObject GO_tooltip { get; set; }



        void Awake()
        {
            if (GO_tooltip == null) { GO_tooltip = GameObject.Find("Tooltip"); }//Gets Tooltip
        }


        void Update()
        {
            if (GO_tooltip.activeSelf)
            {
                GO_tooltip.transform.position = Input.mousePosition;
            }
        }
        public void Activate(Item item)//Activation
        {
            this.item = item;
            ConstructDataString();
            GO_tooltip.SetActive(true);

        }

        public void ConstructDataString()
        {

            GO_tooltip.transform.GetChild(0).GetComponent<Text>().text = item.Title;



        }

        public void Deactivate()
        {
            GO_tooltip.SetActive(false);
        }
    }
}



