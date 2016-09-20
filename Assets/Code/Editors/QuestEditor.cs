using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;

namespace Assets
{
    [CustomEditor(typeof(Quest))]
    class QuestEditor : Editor
    {
        private Quest _quest;
        void Awake()
        {
            _quest = (Quest)target;
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }
    }
}
