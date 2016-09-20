using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class ActionSequence : MonoBehaviour
    {
        public ActionHandler Actions;

        void Awake()
        {
            if (Actions == null)
                Actions = new ActionHandler();

            hideFlags = HideFlags.HideAndDontSave;
        }



    }


}
