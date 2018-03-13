using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TMPro.Examples {
    public class Sell : MonoBehaviour,IPointerClickHandler
    {

        Item item;
        TextMeshProUGUI amountText;
        Button button;
        Inventory inv;
        int a;

        private void Awake()
        {
            amountText = GameObject.Find("SellAmount").GetComponent<TextMeshProUGUI>() ;
            button = GameObject.Find("Sell").GetComponent<Button>();
            amountText.SetText("0");
            inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        }

        
        public void SellItem(Item item,int amount)
        {

            this.item = item;
            a= item.Value * amount;
            amountText.text = a.ToString();

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (item.ID == 0) return;
            
            inv.RemoveItem(item.ID);
            for(int i = 0; i < a; i++)
            {
                inv.AddItem(item.ID);
            }
        }
    }
}

