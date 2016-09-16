using UnityEngine;
using System.Collections;
using Assets;

[RequireComponent(typeof(Collider2D))]
public class ItemGive : MonoBehaviour, Assets.IUseble
{
    public Item item;
    public bool distraсkt = false;

    private ItemManager iM;

    void Start()
    {
        iM = GameObject.FindObjectOfType<ItemManager>();
    }

    public void Use()
    {
        iM.GetItem(item);
        if(distraсkt)
        {
            Destroy(gameObject);
        }
    }
}
