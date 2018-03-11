using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro.Examples {
    public class ItemData : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
    {
        [HideInInspector]
        public Item item;
        [HideInInspector]
        public int amount;

        [HideInInspector]
        public int slotN;//number where slot is


        private Inventory inv;
        private Vector2 offset;

        private void Start()
        {
            inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (item != null) //if there is an item in slot
            {
                offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
                this.transform.SetParent(this.transform.parent.parent);//setting that the parent is a grandparent of the object ake Slot Panel
                this.transform.position = eventData.position;//setting item postion to the event(mouse) postion
                GetComponent<CanvasGroup>().blocksRaycasts = false;

            }
        }

        public void OnDrag(PointerEventData eventData)
        {

            if (item != null)
            {//if there is an item in slot

                this.transform.position = eventData.position - offset;//setting item postion to the event(mouse) postion
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.SetParent(inv.slots[slotN].transform);//setting item back to new  parent
            this.transform.position = inv.slots[slotN].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}

