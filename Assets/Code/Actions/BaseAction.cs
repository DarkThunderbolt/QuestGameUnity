using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public abstract class BaseAction : ScriptableObject
    {
        public bool ActionComplidet = false;

        public abstract void DoAction();

        public void OnEnable() { hideFlags = HideFlags.HideAndDontSave; }

        public BaseAction() { }

        public abstract void DrawInspector();
    }


}
