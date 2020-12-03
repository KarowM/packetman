using System;
using UnityEngine;

public class Ghost : MonoBehaviour {
    public Transform[] _route;
    private int _curPoint = 0;
    
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    void Start() {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private float speed = 0.2f;
    void FixedUpdate() {
        if (transform.position != _route[_curPoint].position) {
            Vector2 movement = Vector2.MoveTowards(transform.position, 
                                             _route[_curPoint].position,
                                                   speed);
            _rigidBody.MovePosition(movement);
        }
        else {
            _curPoint = (_curPoint + 1) % _route.Length;
        }

        Vector2 dir = _route[_curPoint].position - transform.position;
        _animator.SetFloat("DirX", dir.x);
        _animator.SetFloat("DirY", dir.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name.Equals("packetman")) {
            Destroy(other.gameObject);
        }
    }
}