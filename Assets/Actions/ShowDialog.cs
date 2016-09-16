using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class ShowDialog : AGameAction
    {
        public string nameOfDialog;

        public ShowDialog() { }

        public override void DoAction()
        {
            Dialogue newDialog = Serializer.DeSerialize<Dialogue>(nameOfDialog);
            GameObject.FindObjectOfType<DialogManager>().GetDialog(newDialog);
        }
    }
}
