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
        public string Name;
        public string Title;
        public bool IsComplidet;
        public string Description;

        public Quest(string name, string description, string title)
        {
            IsComplidet = false;
            this.Name = name;
            this.Title = title;
            this.Description = description;
        }
    }
}
