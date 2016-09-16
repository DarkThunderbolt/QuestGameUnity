using UnityEngine;
using System.Collections;

public class SomeObject : MonoBehaviour {

    bool i=false;

    public void DoSomething()
    {
        if(i)
        {
            gameObject.transform.localScale = gameObject.transform.localScale / 2;
        }
        else
        {
            gameObject.transform.localScale = gameObject.transform.localScale * 2;
        }
        i = !i;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
