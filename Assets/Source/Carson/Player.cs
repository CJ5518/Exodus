using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cj;

public class Player : MonoBehaviour {
	//Temp Movement implementation
	private Rigidbody2D rigidbody;
	PlayerController m_controller;

	public PlayerController controller {
		get {
			return m_controller;
		}
		set {
			m_controller = value;
		}
	}

	void Start() {
		rigidbody = GetComponent<Rigidbody2D>();
		controller = new PlayerKeyboard();
		var x = PlayerSingleton.Player;
	}

	void Update() {
		controller.handleInput();
	}

	void FixedUpdate() {
		rigidbody.velocity = new Vector2(controller.horizontal * 8, !controller.vertical ? rigidbody.velocity.y : 5.0f);
	}
}
