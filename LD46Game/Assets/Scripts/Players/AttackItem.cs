using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : MonoBehaviour
{
    public float lifeLength;
    Controls controls;

    void Awake() {
        controls = new Controls();
    }
    void Start() {
        Destroy(gameObject, lifeLength);
    }

    void Update() {
      
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag !=  "Basic Attack") {
            //Destroy(gameObject);
        }
    }

    void OnEnable() {
        controls.Enable();
    }
    void OnDisable() {
        controls.Disable();
    }
}
