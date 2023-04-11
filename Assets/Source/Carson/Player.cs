using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cj;

public class Player : MonoBehaviour {
	// Private members
	private Rigidbody2D m_rigidBody;
	private PlayerController m_controller;
	private PlayerState m_playerState;
	private Collider2D m_collider;
	private SpriteRenderer m_spriteRenderer;

	// Basic settings
	[System.NonSerialized] public float jumpForce = 440.0f;
	[System.NonSerialized] public float fallForce = -90.0f;

	// More niche settings
	// The max number of seconds the player can hold space to continue to rise with a jump
	[System.NonSerialized] public float maxJumpRiseTime = 0.75f;

	// The max horizontal and vertical velocity
	private float maxHorizontalSpeed = 10.0f;
	private float maxVerticalSpeed = 20.0f;

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
	//Read-only members

	public Rigidbody2D rigidBody {
		get {
			return m_rigidBody;
		}
	}

	public SpriteRenderer spriteRenderer {
		get {
			return m_spriteRenderer;
		}
	}

	// Is the player grounded or no?
	public bool isGrounded() {
		if (rigidBody.velocity.y <= 0) {
			Debug.Log(rigidBody.velocity.y);
			Vector2 lowerPoint = new Vector2(transform.position.x, transform.position.y - (transform.localScale.y / 2.0f) - 0.1f);
			Vector2 xDelta = new Vector2((transform.localScale.x / 2.0f) - 0.1f, 0.05f);
			Debug.DrawLine(lowerPoint + xDelta, lowerPoint - xDelta, Color.red, 0.0f);
			bool res = Physics2D.OverlapArea(lowerPoint + xDelta, lowerPoint - xDelta);
			return res;
		}
		return false;
	}
	// Is the player falling?
	public bool isFalling() {
		return rigidBody.velocity.y < 0;
	}

	void Start() {
		Application.targetFrameRate = 40;
		m_rigidBody = GetComponent<Rigidbody2D>();
		m_collider = GetComponent<Collider2D>();
		m_spriteRenderer = GetComponent<SpriteRenderer>();
		// Set the controll iff it hasn't already been set externally
		if (controller == null)
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
