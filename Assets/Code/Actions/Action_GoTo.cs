﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets
{
    public class Action_GoTo : BaseAction
    {
        public Transform Place;

        public Action_GoTo() { }

        public override void DoAction()
        {
            GameObject.FindObjectOfType<PlayerMouseController>().MoveToPoint(Place);
        }

        public override void DrawInspector()
        {
            Place = EditorGUILayout.ObjectField(Place, typeof(Transform)) as Transform;
        }
    }
}
