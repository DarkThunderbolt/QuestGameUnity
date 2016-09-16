using UnityEngine;
using System.Collections;

public class FadeScreen : MonoBehaviour
{

    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void FadeOutScreen()
    {
        anim.SetTrigger("LevelEnded");
    }
}

