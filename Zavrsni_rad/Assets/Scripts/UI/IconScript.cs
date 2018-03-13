using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TMPro.Examples {
    public class IconScript : MonoBehaviour, IPointerClickHandler
    {
        private Image img;
        public string Name;
        private Player player;
        public GameObject button;
        public Inventory inv;

        public void OnPointerClick(PointerEventData eventData)
        {
         
                player.ToggleInvenotry();
                Toggel();
           
        }

        // Use this for initialization
        void Awake()
        {
            img = gameObject.GetComponent<Image>();
            player = GameObject.Find("Player").GetComponent<Player>();
            Toggel();
        }

 

        private void Toggel()
        {
            if (button.activeSelf)
            {
                button.SetActive(false);
            }
            else{
                button.SetActive(true);
            }
        }
    }
}

