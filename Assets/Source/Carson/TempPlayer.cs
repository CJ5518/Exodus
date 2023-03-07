using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TempPlayer : MonoBehaviour {
	public Rigidbody2D rigidbody;
	public float horizontal = 0.0f;
	void Start() {
		rigidbody = GetComponent<Rigidbody2D>();
		
	}
}