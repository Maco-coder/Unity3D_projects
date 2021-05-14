using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject ball      ;
    public Transform spawnPoint ;

    void Start() {
        SpawnBall();
    }

    void Update() {
        
    }

    void SpawnBall() {
        Instantiate(ball, spawnPoint.position, Quaternion.identity);
    }
}
