using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class Action_ShowDialog : BaseAction
    {
        public Dialogue Dialog;

        public Action_ShowDialog() { }

        public override void DoAction()
        {
            GameObject.FindObjectOfType<DialogManager>().GetDialog(Dialog);
        }
    }
}
