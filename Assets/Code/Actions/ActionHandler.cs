using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class ActionHandler : ScriptableObject
    {
        public List<BaseAction> ActionList;

        void Awake()
        {
            if (ActionList == null)
                ActionList = new List<BaseAction>();

            hideFlags = HideFlags.HideAndDontSave;
        }

        //public Condition CheckCondition;

        public void OnGUI()
        {
            foreach (BaseAction instance in ActionList)
                instance.DrawInspector();

            if (GUILayout.Button("Add GoTo"))
                ActionList.Add(CreateInstance<Action_GoTo>());

            if (GUILayout.Button("Add GoTo"))
                ActionList.Add(CreateInstance<Action_TakeItem>());
        }


    }


}
