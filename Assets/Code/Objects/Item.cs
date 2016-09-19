using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace Assets
{
    [Serializable]
    public class Item : ScriptableObject
    {
        public Sprite Textura; 
        public string Name;
        public string Description;
    }
}
