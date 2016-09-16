using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Dictionary<GameObject, Item> itemDic;
    public GameObject itemPrefab;
    public GameObject ListGrid;

    private List<Item> itemList;
    private Item selectedQuest;


    // Use this for initialization
    void Start()
    {
        itemList = GameManager.GetInstance().itemList;

        if (itemDic == null) 
        {
            itemDic = new Dictionary<GameObject, Item>();
        }

        foreach (Item q in itemList)
        {
            if (!itemDic.ContainsValue(q))
            {
                AddNewItemToUI(q);
            }
        }
    }


    private void AddNewItemToUI(Item item)
    {
        GameObject newItem = Instantiate(itemPrefab) as GameObject;
        newItem.name = "Item_" + item.name;
        newItem.GetComponent<Image>().overrideSprite = item.Textura;
        newItem.transform.SetParent(ListGrid.transform, false);
        itemDic.Add(newItem, item);
    }

    public void GetItem(Item item)
    {
        if (!itemDic.ContainsValue(item)) 
        {
            itemList.Add(item);
            AddNewItemToUI(item);
        }
    }


    public void ClickOnItem(GameObject clickedButton)
    {
        //Debug.Log(gameObject);
        //selectedQuest = itemDic[clickedButton];
        //selectedQuestTitle.text = selectedQuest.title;
        //selectedQuestDesc.text = selectedQuest.description;
    }
}
