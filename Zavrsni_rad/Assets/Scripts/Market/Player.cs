using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMPro.Examples {
    public class Player : MonoBehaviour
    {

        private GameObject Canvas_GO;
        private IconScript buy,sell;

    private void Start()
        {
            Canvas_GO = GameObject.Find("Canvas_Invenotry");
            buy = GameObject.Find("Buy_UI").GetComponent<IconScript>();
            sell = GameObject.Find("Sell_UI").GetComponent<IconScript>();
            ToggleInvenotry();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ToggleInvenotry();
            }

        }

        public void ToggleInvenotry()//toggels on off invenotry panel
        {
            buy.button.SetActive(false);
            sell.button.SetActive(false);

            if (Canvas_GO.activeSelf)
            {
                Canvas_GO.SetActive(false);
            }
            else
            {
                Canvas_GO.SetActive(true);
            }
        }
    }
}

