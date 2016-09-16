using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Assets;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{

    public Texture2D cursorTexture;
    public Transform leftPoint;
    public Transform rigthPoint;
    public float usebleDistanse = 5;
    public bool autoUse = false;


    private PlayerMouseController player;
    private IUseble[] useObjects;
    private bool mouseOn = false;
    private bool mastBeUsed = false;

    void Start ()
    {
        player = GameObject.FindObjectOfType<PlayerMouseController>();
        useObjects = gameObject.GetComponents<IUseble>();
    }
	
	void Update ()
    {
        if (mouseOn)
        {
            if (Input.GetMouseButtonDown(0) && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                float distanse = gameObject.transform.position.x - player.transform.position.x;
                if (Mathf.Abs(distanse) <= usebleDistanse)
                {
                    foreach (IUseble user in useObjects)
                    {
                        user.Use();
                    }
                    mastBeUsed = false;
                }
                else
                {
                    if( leftPoint == null)
                    {
                        player.MoveToPoint(rigthPoint);
                    }
                    else if( rigthPoint ==null)
                    {
                        player.MoveToPoint(leftPoint);
                    }
                    else if (distanse > 0)
                    {
                        player.MoveToPoint(leftPoint);
                    }
                    else
                    {
                        player.MoveToPoint(rigthPoint);
                    }

                    if(autoUse)
                    {
                        mastBeUsed = true;
                    }
                }
            }           
        }
        if(mastBeUsed)
        {
            if (Mathf.Abs(gameObject.transform.position.x - player.transform.position.x) <= usebleDistanse)
            {
                foreach (IUseble user in useObjects)
                {
                    user.Use();
                }
                mastBeUsed = false;
            }
        }
    }

    void OnMouseEnter()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
            mouseOn = true;
        }
    }

    void OnMouseExit()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            mouseOn = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, usebleDistanse);
    }

}
