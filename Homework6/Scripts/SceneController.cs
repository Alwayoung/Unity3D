using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	float scores;
	public int patrolNumb = 5;
	private int EscaptedPatrolNumb = 0;
	public SPatrolFactory patrolFac;

	public bool isGameOver = false;
	
	void RestartGame() {
		scores = 0;
		EscaptedPatrolNumb = 0;
		isGameOver = false;
		patrolFac.GenPatrol(patrolNumb);
	}

	// Use this for initialization
	void Start () {
		patrolFac = Singleton<SPatrolFactory>.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameOver() {
		Debug.Log("Game Over");
		isGameOver = true;
		patrolFac.ReleaseAllPatrols();
	}

	public void AddScore(float tempScore) {
		if (EscaptedPatrolNumb < patrolNumb) {
			scores += tempScore;
			if (++EscaptedPatrolNumb == patrolNumb) {
				GameOver();
			}
		}
		
	}

	void OnGUI() {
		if (GUI.Button(new Rect(20, 20, 20, 20), "S")) {
			RestartGame();
		}

		GUI.Button(new Rect(50, 20, 150, 20), "Score : " + scores.ToString());
	}
}
