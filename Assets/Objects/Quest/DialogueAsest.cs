using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets
{
    public class QuestAsest
    {
        [MenuItem("Assets/Create/Quest")]
        public static void CreateAsset()
        {
            CustomAssetUtility.CreateAsset<Quest>();
        }
    }
}
