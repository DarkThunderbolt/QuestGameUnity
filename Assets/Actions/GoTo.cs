using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class GoTo : AGameAction
    {
        public Transform place;

        public GoTo() { }

        public override void DoAction()
        {
            GameObject.FindObjectOfType<PlayerMouseController>().MoveToPoint(place);
        }
    }
}
