using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class Quest : ScriptableObject
    {
        public string name;
        public string title;
        public bool isComplidet;
        public string description;

        public Quest(string name, string description, string title)
        {
            isComplidet = false;
            this.name = name;
            this.title = title;
            this.description = description;
        }
    }
}
