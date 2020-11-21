using System;
using UnityEngine;

public class Packet : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name.Equals("packetman")) {
            Destroy(gameObject);
        }
    }
}