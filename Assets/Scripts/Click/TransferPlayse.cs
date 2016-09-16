using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Collider))]
public class TransferPlayse : MonoBehaviour, Assets.IUseble
{
    public string nextScenName;
    public Transform transferPoint;

    public void Use()
    {
        StartCoroutine(ExitFromScene());
    }

    IEnumerator ExitFromScene()
    {
        if(transferPoint !=null)
            GameObject.FindObjectOfType<PlayerMouseController>().MoveToPoint(transferPoint);
        FindObjectOfType<FadeScreen>().FadeOutScreen();
        yield return new WaitForSeconds(0.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScenName);
    }
}
