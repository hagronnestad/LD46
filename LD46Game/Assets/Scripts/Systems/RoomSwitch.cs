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

     void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            followCamera.minCamPos.x += cameraSwitch.x;
            followCamera.maxCamPos.x = 100;
            followCamera.minCamPos.y += cameraSwitch.y;
            followCamera.maxCamPos.y += cameraSwitch.y;
            collision.transform.position += playerSwitch;
        }
    }
}
