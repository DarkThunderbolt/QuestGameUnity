using UnityEngine;
using System.Linq;
using System.Collections;

using System.Collections.Generic;
using Assets;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Dictionary<GameObject, Quest> questDic;
    public GameObject itemPrefab;
    public Text selectedQuestTitle;
    public Text selectedQuestDesc;
    public GameObject ListGrid;

    private List<Quest> questList;
    private Quest selectedQuest;
    //private bool updated = false;

    // Use this for initialization
    void Start()
    {
        questList = GameManager.GetInstance().questList;

        if (questDic==null)
        {
            questDic = new Dictionary<GameObject, Quest>();
        }

        foreach(Quest q in questList)
        {
            if (!questDic.ContainsValue(q))
            {
                AddNewQuestToUI(q);
            }
        }
        
    }
	
	// Update is called once per frame
	/*void Update ()
    {
	    if(updated)
        {
          
        }
	}*/

    private void AddNewQuestToUI(Quest quest)
    {
        GameObject newItem = Instantiate(itemPrefab) as GameObject;
        newItem.name = "Quest_" + quest.Name;

        Button clickable = newItem.GetComponent<Button>();
        clickable.onClick.AddListener(newItem.GetComponent<ListButton>().ClickButton);

        newItem.GetComponentInChildren<Text>().text = quest.Name;
        newItem.transform.SetParent(ListGrid.transform, false);
        questDic.Add(newItem,quest);
    }

    public void TakeNewQuest(Quest newQuest)
    {
        if (!questDic.ContainsValue(newQuest))
        {
            questList.Add(newQuest);
            AddNewQuestToUI(newQuest);
        }
    }

    public void ChangeQustStatus(string questName, bool status)
    {

    }

    public void ClickOnQuest(GameObject clickedButton)
    {
        Debug.Log(gameObject);
        selectedQuest = questDic[clickedButton];
        selectedQuestTitle.text = selectedQuest.Title;
        selectedQuestDesc.text = selectedQuest.Description;
    }
}
