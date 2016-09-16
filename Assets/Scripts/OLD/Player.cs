using UnityEngine;
using System.Collections;
/// <summary>
/// !!!OLD!!!
/// </summary>
[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

    public int currentHealth;
    public int currentAmmo;

    private int _maxHealth = 100;
    private int _maxAmmo = 100;
    private float _moveSpeed = 8;
    private int _extraJump;
    private int _originExtraJumps = 1;

    private Controller2D _controller;

    private Rigidbody2D _body;

    // Use this for initialization
    void Start()
    {
        _controller = GetComponent<Controller2D>();
        //_controller.SetJumps(_extraJump);
        _body = GetComponent<Rigidbody2D>();
      

        currentHealth = _maxHealth;
        currentAmmo = _maxAmmo;
        //_extraJump = _originExtraJumps;
    }

    void FixedUpdate()
    {
        _controller.Move(_moveSpeed);
    }
}
