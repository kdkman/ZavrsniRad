using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TMPro.Examples {
    public class ItemData : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler { 

        public Item item;
        public int amount;
        private Tooltip tooltip;

        private Sell sell=null;

        public int slotN;//number where slot is


        private Inventory inv;
        private Vector2 offset;
        public GameObject slotPanel;
        public Transform originalParent;



        void Awake()
        {
            inv = GameObject.Find("Inventory").GetComponent<Inventory>();


            tooltip = inv.GetComponent<Tooltip>();
            tooltip.GO_tooltip.SetActive(false);//setts UI toolTip hidden


        }

        public void OnDrag(PointerEventData eventData)
        {
                
            if (item != null)
         
            {//if there is an item in slot

        
                GetComponent<CanvasGroup>().blocksRaycasts = false;

                this.transform.position = eventData.position - offset;//setting item postion to the event(mouse) postion
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {


            this.transform.SetParent(inv.slots[slotN].transform);//setting item  to new  parent
            this.transform.position = inv.slots[slotN].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            

        }

        public void OnPointerExit(PointerEventData eventData)
        {

        }

  
    }
}

