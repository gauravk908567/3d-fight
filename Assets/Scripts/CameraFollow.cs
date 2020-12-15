using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;
    
    public Vector3 offsetPosition;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Followplayer();
    }

    void Followplayer()
    {
        transform.position = Player.TransformPoint(offsetPosition);
        transform.rotation = Player.rotation;
    }
}//class
