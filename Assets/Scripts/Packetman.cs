using System;
using UnityEngine;

public class Packetman : MonoBehaviour {
    private const float Speed = 0.2f;
    private Vector2 _dest;

    private Collider2D _collider;
    private Rigidbody2D _rigidBody;

    void Start() {
        _dest = transform.position;
        _collider = GetComponent<Collider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float roundx = (float)Math.Round(transform.position.x, 1);
        float roundy = (float)Math.Round(transform.position.y, 1);
        transform.position = new Vector3(roundx, roundy, transform.position.z);

        Vector2 currentPos = transform.position;
        if (currentPos == _dest) {
            if (Input.GetKey(KeyCode.UpArrow) && canMove(Vector2.up)) {
                _dest = currentPos + Vector2.up;
            }
            if (Input.GetKey(KeyCode.DownArrow) && canMove(Vector2.down)) {
                _dest = currentPos + Vector2.down;
            }
            if (Input.GetKey(KeyCode.RightArrow) && canMove(Vector2.right)) {
                _dest = currentPos + Vector2.right;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && canMove(Vector2.left)) {
                _dest = currentPos + Vector2.left;
            }
        }
        _rigidBody.MovePosition(Vector2.MoveTowards(transform.position, _dest, Speed));
    }

    private bool canMove(Vector2 dir) {
        Vector2 pos = transform.position;
        return Physics2D.Linecast(pos + dir, pos).collider == _collider;
    }
}