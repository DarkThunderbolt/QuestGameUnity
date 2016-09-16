using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class TakeItem : AGameAction
    {
        public Item item;

        public TakeItem() { }

        public override void DoAction()
        {
            GameObject.FindObjectOfType<ItemManager>().GetItem(item);
        }
    }
}
