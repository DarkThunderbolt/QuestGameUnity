using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class Dialogue: ScriptableObject
    {
        public string Name;
        public List<Replica> Replicas;
        public AGameAction NextAction;
        
        public Dialogue()
        {
            Replicas = new List<Replica>();
        }

        public Dialogue(string name)
        {
            Name = name;
            Replicas = new List<Replica>();
        }
    }
   
}
