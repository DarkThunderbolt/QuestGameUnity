using UnityEngine;
using System.Collections;

public class ListButton : MonoBehaviour
{

    public void ClickButton()
    {
        GameObject.FindObjectOfType<QuestManager>().ClickOnQuest(gameObject);
    }

}
