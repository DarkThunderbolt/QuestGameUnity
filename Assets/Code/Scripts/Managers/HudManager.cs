using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets;

public class HudManager : MonoBehaviour
{
    [SerializeField]
    public BaseAction[] actionTestList;
    bool quest = false;
    bool inv = false;
    public  GameObject questQ;
    public GameObject invI;

    public void OpenQuestWindow()
    {
        quest = !quest;
        questQ.SetActive(quest);
    }

    public void OpenInventoryWindow()
    {
        inv = !inv;
        invI.SetActive(inv);

    }
}
