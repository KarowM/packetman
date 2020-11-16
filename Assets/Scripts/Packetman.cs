using System;
using UnityEngine;

public class Packetman : MonoBehaviour {
    private float speed = 0.2f;
    private Vector2 dest;

    private Collider2D collider;

    void Start() {
        dest = transform.position;
        collider = GetComponent<Collider2D>();
    }

    void FixedUpdate() {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        Vector2 currentPos = transform.position;
        if (currentPos == dest) {
            if (Input.GetKey(KeyCode.UpArrow) && canMove(Vector2.up)) {
                dest = currentPos + Vector2.up;
            }
            if (Input.GetKey(KeyCode.DownArrow) && canMove(Vector2.down)) {
                dest = currentPos + Vector2.down;
            }
            if (Input.GetKey(KeyCode.RightArrow) && canMove(Vector2.right)) {
                dest = currentPos + Vector2.right;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && canMove(Vector2.left)) {
                dest = currentPos + Vector2.left;
            }
        }
    }

    private bool canMove(Vector2 dir) {
        Vector2 pos = transform.position;
        RaycastHit2D hit;
        hit = Physics2D.Linecast(pos + dir, pos);
        Debug.DrawLine(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}