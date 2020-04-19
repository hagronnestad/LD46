using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitch : MonoBehaviour
{
    public Vector3 cameraSwitch;
    public Vector3 playerSwitch;

    FollowCamera followCamera;
    void Start()
    {
        followCamera = Camera.main.GetComponent<FollowCamera>();
    }

    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            followCamera.minCamPos += cameraSwitch;
            followCamera.maxCamPos += cameraSwitch;
            collision.transform.position += playerSwitch;
        }
    }
}
