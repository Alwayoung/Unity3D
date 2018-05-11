using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GameEvents {
    public static void StartChasing(SPatrol spa, Transform player) {
        if (Singleton<SceneController>.Instance.isGameOver || spa.hasBeenEscapedFrom)
           return;
        Debug.Log(spa.name + " Start Chasing Player");
        spa.hasDiscoverAPlayer = true;
        spa.chasingPlayer = player;
    }

    public static void CollidePlayer(SPatrol spa) {
        if (spa.hasBeenEscapedFrom || Singleton<SceneController>.Instance.isGameOver) 
            return;
        Debug.Log(spa.name + " Collide Player");
        Singleton<SceneController>.Instance.GameOver();
    }

    public static void LeavePlayer(SPatrol spa) {
        if (Singleton<SceneController>.Instance.isGameOver || spa.hasBeenEscapedFrom) 
            return;
        Debug.Log (spa.name + " Leave Player");
        spa.SetEscapedColor();
        Singleton<SceneController>.Instance.AddScore(spa.speed);
        spa.hasDiscoverAPlayer = false;
        spa.chasingPlayer = null;
        spa.hasBeenEscapedFrom = true;
    }
}
