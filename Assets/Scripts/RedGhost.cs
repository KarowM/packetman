using System;
using UnityEngine;

public class RedGhost : MonoBehaviour {
    private Vector2[] _route;
    private int _curPoint = 0;
    
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    void Start() {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _route = CreateRoute();
    }

    private float speed = 0.2f;

    void FixedUpdate() {
        if ((Vector2)transform.position != _route[_curPoint]) {
            Vector2 movement = Vector2.MoveTowards(transform.position, 
                                             _route[_curPoint],
                                                   speed);
            _rigidBody.MovePosition(movement);;
        }
        else {
            _curPoint = (_curPoint + 1) % _route.Length;
        }

        Vector2 dir = _route[_curPoint] - (Vector2)transform.position;
        _animator.SetFloat("DirX", dir.x);
        _animator.SetFloat("DirY", dir.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name.Equals("packetman")) {
            FindObjectOfType<LifeManager>().PlayerDeath();
        }
    }

    private Vector2[] CreateRoute() {
        Vector2[] route = new Vector2[32];
        route[0] = new Vector2(5, 4);
        route[1] = new Vector2(5, -5);
        route[2] = new Vector2(13, -5);
        route[3] = new Vector2(13, -8);
        route[4] = new Vector2(11, -8);
        route[5] = new Vector2(11, -11);
        route[6] = new Vector2(8, -11);
        route[7] = new Vector2(8, -14);
        route[8] = new Vector2(-7, -14);
        route[9] = new Vector2(-7, -5);
        route[10] = new Vector2(-10, -5);
        route[11] = new Vector2(-10, -2);
        route[12] = new Vector2(-12, -2);
        route[13] = new Vector2(-12, 1);
        route[14] = new Vector2(-7, 1);
        route[15] = new Vector2(-7, 10);
        route[16] = new Vector2(-12, 10);
        route[17] = new Vector2(-12, 14);
        route[18] = new Vector2(-1, 14);
        route[19] = new Vector2(-1, 12);
        route[20] = new Vector2(2, 12);
        route[21] = new Vector2(2, 14);
        route[22] = new Vector2(13, 14);
        route[23] = new Vector2(13, 10);
        route[24] = new Vector2(2, 10);
        route[25] = new Vector2(2, 12);
        route[26] = new Vector2(-1, 12);
        route[27] = new Vector2(-1, 10);
        route[28] = new Vector2(-4, 10);
        route[29] = new Vector2(-4, 7);
        route[30] = new Vector2(-1, 7);
        route[31] = new Vector2(-1, 4);
        return route;
    }
}