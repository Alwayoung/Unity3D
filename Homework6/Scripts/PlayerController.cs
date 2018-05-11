using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 3.0f;

	void Start () {
		
	}
	
	void Update () {
		float translationZ = Input.GetAxis("Vertical");
		float translationX = Input.GetAxis("Horizontal");
		Vector3 vec = new Vector3(translationX, 0, translationZ);

		transform.Translate(vec.normalized * speed);
	}
}
