using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class Action_ChangeScene : BaseAction
    {
        public Scene NextScenName;

        public Action_ChangeScene() { }

        public override void DoAction()
        {
            //GameObject.FindObjectOfType<FadeScreen>().FadeOutScreen();
            //new WaitForSeconds(0.5f);
            //UnityEngine.SceneManagement.SceneManager.LoadScene(NextScenName);
        }

        public override void DrawInspector()
        {
          //  EditorGUILayout.ObjectField(TakenItem, typeof(Item));
        }
    }
}
