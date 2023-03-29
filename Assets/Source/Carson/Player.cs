using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cj;

public class Player : MonoBehaviour {
	//Temp Movement implementation
	private Rigidbody2D m_rigidBody;
	private PlayerController m_controller;
	private PlayerState m_playerState;

	// The max horizontal and vertical velocity
	private float maxHorizontalSpeed = 10.0f;
	private float maxVerticalSpeed = 10.0f;

	public PlayerController controller {
		get {
			return m_controller;
		}
		set {
			m_controller = value;
		}
	}

	// Get and set the player state, handled by the PlayerState class
	public PlayerState playerState {
		get {
			return m_playerState;
		}
		set {
			m_playerState = value;
		}
	}

	public Rigidbody2D rigidBody {
		get {
			return m_rigidBody;
		}
	}

	void Start() {
		Application.targetFrameRate = 40;
		m_rigidBody = GetComponent<Rigidbody2D>();
		controller = new PlayerKeyboard();
		playerState = new PlayerStateAirborne(this);
	}

	void Update() {
		controller.gatherInput();
		playerState.update(Time.deltaTime);
	}

	void FixedUpdate() {
		playerState.fixedUpdate();
		capSpeed();
	}


	// Collision related function, just pass them to the state
	void OnCollisionEnter2D(Collision2D collision) {
		playerState.onCollisionEnter2D(collision);
	}
	void OnCollisionStay2D(Collision2D collision) {
		playerState.onCollisionStay2D(collision);
	}
	void OnCollisionExit2D(Collision2D collision) {
		playerState.onCollisionExit2D(collision);
	}

	// Cap the players speed at the maximums defined above
	private void capSpeed() {
		if (Mathf.Abs(rigidBody.velocity.x) > maxHorizontalSpeed) {
			rigidBody.velocity = new Vector2(rigidBody.velocity.x < 0 ? -maxHorizontalSpeed : maxHorizontalSpeed, rigidBody.velocity.y);
		}
		if (Mathf.Abs(rigidBody.velocity.y) > maxVerticalSpeed) {
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y < 0 ? -maxVerticalSpeed : maxVerticalSpeed);
		}
	}
}
