using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove1 : MonoBehaviour {
     Vector3 pointA = new Vector3(-52.85f, 0.5f, -2.5f);
     Vector3 pointB = new Vector3(-67.15f, 0.5f, -2.5f);

     //Vector3 pointA = new Vector3(7.15f, 0.5f, -5.0f);
     //Vector3 pointB = new Vector3(-7.15f, 0.5f, -5.0f); 

    private float speed = 0.5f;
     

     void Update() {

         transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time * speed, 1));
     } 


 }
