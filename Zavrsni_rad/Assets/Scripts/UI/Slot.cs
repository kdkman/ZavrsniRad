using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro.Examples {
    public class Slot : MonoBehaviour, IDropHandler
    {
        private Inventory inv;
        public int id;

        void Start()
        {
     
            inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        }


        public void OnDrop(PointerEventData eventData)
        {
            print(inv.items[id].ID);
            ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();

            if (inv.items[id].ID == -1)//if there is no item
            {
                inv.items[droppedItem.slotN] = new Item();//killing old slot makeing new 
                inv.items[id] = droppedItem.item; //adding new item in the new slot
                droppedItem.slotN = id;// if it is on new slot 
            }

            else //this is switching placese of items in slot preety bad accutaly need to understand this
                 //TODO can use this for buying AND SELLNG 
            {
                //setting the item in the slot to dropItems postion
                Transform item = this.transform.GetChild(0);//getting item from slot
                item.GetComponent<ItemData>().slotN = droppedItem.slotN; //seting slot to drop item
                item.transform.SetParent(inv.slots[droppedItem.slotN].transform);//setting old slot for parent
                item.transform.position = inv.slots[droppedItem.slotN].transform.position; //puting it in the right place


                //TODO coment this //seting dropitem to new slot MAYBE PUt it in setter
                droppedItem.slotN = id;
                droppedItem.transform.SetParent(this.transform);
                droppedItem.transform.position = this.transform.position;

                inv.items[droppedItem.slotN] = item.GetComponent<ItemData>().item;
                inv.items[id] = droppedItem.item;
                
            }

            //TODO if its out of invenotry drop item
        }
    }

}

