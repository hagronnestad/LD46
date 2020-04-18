using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : MonoBehaviour
{
    public GameObject explosion;
    public float lifeLength;
    void Start() {
        Destroy(gameObject, lifeLength);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag !=  "Basic Attack") {
            GameObject explosionEffect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionEffect, 1f);
            Destroy(gameObject);
        }
    }
}
