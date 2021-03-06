﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace TMPro.Examples
{
    public class Inventory : MonoBehaviour
    {
        GameObject invenotryPanel;
        GameObject slotPanel;
        public GameObject invenotrySlot;
        public GameObject invenotryItem;
        public ItemDatabase database;

        private int slotAmount = 16;
        public List<Item> items = new List<Item>();
        public List<GameObject> slots = new List<GameObject>();

        private void Awake()
        {
            database = GetComponent<ItemDatabase>();
            invenotryPanel = GameObject.Find("Invenotry Panel");
            slotPanel = GameObject.Find("Slot Panel");
            for (int i = 0; i < slotAmount; i++)
            {
                items.Add(new Item());//setting items fill the up later
                slots.Add(Instantiate(invenotrySlot));//at slots add prefabslot
                slots[i].GetComponent<Slot>().id = i; // setting id
                slots[i].transform.SetParent(slotPanel.transform);//setting slot in panal //parent style 
            }



            AddItem(0);
            AddItem(1);
            AddItem(2);

        }

        public void AddItem(int id)
        {
            Item itemToAdd = database.FetchItemByID(id);


            if (itemToAdd.Stackable)
            {

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].ID == id)
                    {
                        ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>(); //get ItemData componet from first child in item
                        data.amount++;//adds ONLY ONE !!!
                        data.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(data.amount.ToString());
                        break;
                    }
                    else
                    {
                        items[i] = itemToAdd;//add tiem in panel 
                        GameObject itemObj = Instantiate(invenotryItem);//create UI
                        itemObj.GetComponent<ItemData>().item = itemToAdd; //setting itemData item to itemToadd so it knows which item it is
                        itemObj.transform.SetParent(slots[i].transform);//setting UI to be a child of slot in I position
                        itemObj.transform.position = Vector2.zero; //setting its postiion in centar in slot
                        itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite; //setting sprite image to object
                        itemObj.name = itemToAdd.Title;
                        slots[i].transform.GetChild(0).GetComponent<ItemData>().amount++;
                        break;
                    }

                }

            }
            else
            {
                for (int i = 0; i < slotAmount; i++)
                {
                    if (items[i].ID == -1)//if empty //empty is when id =-1
                    {
                        items[i] = itemToAdd;//add tiem in panel 
                        GameObject itemObj = Instantiate(invenotryItem);//create UI
                        itemObj.GetComponent<ItemData>().item = itemToAdd; //setting itemData item to itemToadd so it knows which item it is
                        itemObj.GetComponent<ItemData>().slotN = i;//setting where slot is in;
                        itemObj.transform.SetParent(slots[i].transform);//setting UI to be a child of slot in I position
                        itemObj.transform.position = Vector2.zero; //setting its postiion in centar in slot
                        itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite; //setting sprite image to object
                        itemObj.name = itemToAdd.Title;
                        slots[i].transform.GetChild(0).GetComponent<ItemData>().amount++;
                        break;
                    }
                }
            }

        }

        public void RemoveItem(int id)
        {

            int amout = 100;
            Item itemToRemove = database.FetchItemByID(id);
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    print("loks");
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>(); //get ItemData componet from first child in item
                    data.amount--;//removes ONLY ONE !!!
                    amout = data.amount;
                    data.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(data.amount.ToString());
                    break;
                }
            }
            if (amout < 1)
            {
                print("lok13s");
                Item a = new Item();
                items[id] = a;
                items[id].Sprite = a.Sprite;
                
            }
        }
    }
}
