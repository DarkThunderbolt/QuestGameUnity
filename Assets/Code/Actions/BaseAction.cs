using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class BaseAction
    {
        public bool ActionComplidet = false;

        public virtual void DoAction() { }

        public BaseAction() { }
    }


}
