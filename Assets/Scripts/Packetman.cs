using System;
using UnityEngine;

public class Packetman : MonoBehaviour {
    private float speed = 0.4f;
    private Vector2 dest;

    void Start() {
        dest = transform.position;
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
        return true;
    }
}