using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class DialogGive : MonoBehaviour, Assets.IUseble
{
    public string quest;
    private DialogManager dm;

    private void Start ()
    {
        dm = GameObject.FindObjectOfType<DialogManager>();
    }

    public void Use()
    {
       // dm.GetDialog(quest);
    }
}
