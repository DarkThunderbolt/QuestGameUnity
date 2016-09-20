using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets
{
    public class Action_TakeItem : BaseAction
    {
        public Item TakenItem;

        public Action_TakeItem() { }

        public override void DoAction()
        {
            GameObject.FindObjectOfType<ItemManager>().GetItem(TakenItem);
        }

        public override void DrawInspector()
        {
            EditorGUILayout.ObjectField(TakenItem, typeof(Item));
        }
    }
}
