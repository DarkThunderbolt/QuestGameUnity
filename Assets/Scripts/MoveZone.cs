using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class MoveZone : MonoBehaviour
{
    public Transform[] movePoints;

    private PlayerMouseController player;
    private bool mouseOn;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMouseController>();
    }

    void Update()
    {
        if (mouseOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (movePoints.Length > 1)
                {
                    Transform nearestPoint = movePoints[0];
                    float distanseToNear = Mathf.Abs(mousePosition.x - movePoints[0].position.x);
                    for (int i = 1 ; i<movePoints.Length ; i++)
                    {
                        float dist = Mathf.Abs(mousePosition.x - movePoints[i].position.x);
                        if (dist < distanseToNear)
                        {
                            nearestPoint = movePoints[i];
                            distanseToNear = dist;
                        }
                    }
                    player.MoveToPoint(nearestPoint);
                }
                else
                {
                    player.MoveToPoint(movePoints[0]);
                }
            }
        }
    }
    
    void OnMouseEnter()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            mouseOn = true;
    }

    void OnMouseExit()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            mouseOn = false;
    }

    void OnDrawGizmos()
    {
      // Gizmos.DrawWireSphere(gameObject.transform.position, usebleDistanse);
    }

}
