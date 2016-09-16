using UnityEngine;
using System.Collections;
using Assets;

[RequireComponent(typeof(Collider2D))]
public class QuestGive : MonoBehaviour, Assets.IUseble
{
    public Quest givenQuest;
    private QuestManager qM;
    private bool wasInteracted = false;

    void Start()
    {
        qM = GameObject.FindObjectOfType<QuestManager>();
    }

    public void Use()
    {
        if(wasInteracted)
        {
            wasInteracted = true;
            qM.TakeNewQuest(givenQuest);
        }
    }

}
