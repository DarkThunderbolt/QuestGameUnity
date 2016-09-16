using UnityEngine;
using System.Collections;

public class MyTestObject : MonoBehaviour, Assets.IUseble
{
    private bool a = false;

    public void Use()
    {
        if(!a)
        {
            gameObject.transform.localScale /= 2;
            a = true;
        }
        else
        {
            gameObject.transform.localScale *= 2;
            a = false;
        }
    }
}
