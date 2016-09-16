using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Assets;



[RequireComponent(typeof(Collider2D))]
public class Interactions : MonoBehaviour {

    public bool canBeUsed = false;
    public UnityEvent use;
    public bool wasInteracted =false;



    void Start ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canBeUsed = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canBeUsed = false;
            wasInteracted = false;
        }
    }

    void Update ()
    {
        if (canBeUsed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                wasInteracted = true;
                use.Invoke();
               // giveQuest.Invoke(new Quest("Test qiven quest", "From Snowman whith love", "From Snowman whith love"));
            }
        }
	}

    void OnGUI()
    {
        if (canBeUsed && !wasInteracted)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Press 'E' to interact");
        }
    }
}