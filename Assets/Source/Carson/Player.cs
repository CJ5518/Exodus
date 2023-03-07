using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cj;

public class Player : MonoBehaviour {
	//Temp Movement implementation
	private Rigidbody2D rigidbody;
	private float horizontal = 0.0f;
	void Start() {
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		horizontal = 0.0f;
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			horizontal = -1.0f;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			horizontal = 1.0f;
		}
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, 5.0f);
		}
	}

	void FixedUpdate() {
		rigidbody.velocity = new Vector2(horizontal * 8, rigidbody.velocity.y);
	}
}
