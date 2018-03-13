using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {

    private List<Item> database = new List<Item>(); //contains all items
    private JsonData itemData; // contains json stream


	void Awake  () {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));//converto from json to C# from text in file at aplicaiton location + string
        ConstructItemDataBase();

    }

    public Item FetchItemByID(int id)
    {
        for(int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id) {
                
            return database[i]; }
        }
        return null;
    }

    private void ConstructItemDataBase()
    {
        for (int i = 0; i < itemData.Count; i++)
        { //creat item by itemdata and type casting them to mach
            database.Add(
                new Item(
                (int)itemData[i]["id"],
                itemData[i]["title"].ToString(), (int)itemData[i]["value"],
                (int)itemData[i]["stats"]["power"], (int)itemData[i]["stats"]["defence"],
                 (int)itemData[i]["stats"]["vitality"], itemData[i]["description"].ToString(),
                 (bool)itemData[i]["stackable"], (int)itemData[i]["rarity"], itemData[i]["slug"].ToString()
                        )
                 );
        }
    }

}


