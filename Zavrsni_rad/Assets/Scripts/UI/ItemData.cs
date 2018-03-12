using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro.Examples {
    public class ItemData : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler,IPointerEnterHandler,IPointerExitHandler
    {
        [HideInInspector]
        public Item item;
        [HideInInspector]
        public int amount;
        private Tooltip tooltip;


        [HideInInspector]
        public int slotN;//number where slot is


        private Inventory inv;
        private Vector2 offset;

         void Awake()
        {
            inv = GameObject.Find("Inventory").GetComponent<Inventory>();


            tooltip = inv.GetComponent<Tooltip>();
            tooltip.GO_tooltip.SetActive(false);//setts UI toolTip hidden

        }

        public void OnPointerDown(PointerEventData eventData)
        {

            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        }

        public void OnDrag(PointerEventData eventData)
        {

            if (item != null)
         
            {//if there is an item in slot

        
                GetComponent<CanvasGroup>().blocksRaycasts = false;
                //fix position

                this.transform.position = eventData.position - offset;//setting item postion to the event(mouse) postion
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.SetParent(inv.slots[slotN].transform);//setting item back to new  parent
            this.transform.position = inv.slots[slotN].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.Activate(item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Deactivate();
        }
    }
}

