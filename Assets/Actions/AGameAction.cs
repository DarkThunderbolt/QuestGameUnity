using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class AGameAction
    {
        public bool actionComplidet = false;

        public virtual void DoAction() { }

        public AGameAction() { }
    }


}
