using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class ChangeScene : AGameAction
    {
        public string nextScenName;

        public ChangeScene() { }

        public override void DoAction()
        {
            GameObject.FindObjectOfType<FadeScreen>().FadeOutScreen();
            new WaitForSeconds(0.5f);
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScenName);
        }
    }
}
