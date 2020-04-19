using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : MonoBehaviour
{
    public GameObject explosion;
    public float lifeLength;
    Controls controls;

    Vector2 attackPos;

    void Awake() {
        controls = new Controls();
        controls.PlayerActions.BasicAttack.performed += ctx => attackPos = ctx.ReadValue<Vector2>();
    }
    void Start() {
        Destroy(gameObject, lifeLength);
    }

    void Update() {
        if(attackPos.magnitude > 0.1f) {

        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag !=  "Basic Attack") {
            GameObject explosionEffect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionEffect, 1f);
            Destroy(gameObject);
        }
    }

    void OnEnable() {
        controls.Enable();
    }
    void OnDisable() {
        controls.Disable();
    }
}
