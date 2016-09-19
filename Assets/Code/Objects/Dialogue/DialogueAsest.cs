using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;

namespace Assets
{
    public class DialogueAsest
    {
        [MenuItem("Assets/Create/Dialogue")]
        public static void CreateAsset()
        {
            CustomAssetUtility.CreateAsset<Dialogue>();
        }
    }
}
