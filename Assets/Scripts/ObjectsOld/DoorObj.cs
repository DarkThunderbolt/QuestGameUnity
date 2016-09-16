using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DoorObj : MonoBehaviour, Assets.IUseble
{
    public string nextScenName;
    public void Use()
    {
        GameObject.FindObjectOfType<PlayerMouseController>();
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScenName);
    }
}
