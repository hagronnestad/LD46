using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public AudioSource ambientSound;
    void Start()
    {
        ambientSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    // void OnTriggerEnter2D(Collision2D collision) {
    //    if(collision.gameObject.tag == "Player") {
    //        ambientSound.Play();
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            ambientSound.Play();
        }
    }
    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            ambientSound.Stop();
        }
    }
}
