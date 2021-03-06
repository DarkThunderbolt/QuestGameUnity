﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    [Serializable]
    public class Replica
    {
        public string NameOfCharacter;
        public string TextOfReplica;
        public string ImageOfReplica;
        public bool LeftPlayce;

        public Replica() {}

        public Replica(string name, string text, string image, bool left = true)
        {
            NameOfCharacter = name;
            TextOfReplica = text;
            LeftPlayce = left;
            ImageOfReplica = image;
        }
    }
}
