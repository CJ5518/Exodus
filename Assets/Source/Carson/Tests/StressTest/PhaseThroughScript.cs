using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseThroughScript : MonoBehaviour {
	Player player;
	Rigidbody2D rb;
	public Text text;
	void Start() {
		player = PlayerSingleton.Player;
		rb = player.GetComponent<Rigidbody2D>();
		Application.targetFrameRate = 30;
		doRun();
	}

	void Update() {
		if (!findInRange) {
			if ((int)rb.velocity.y >= 0) {
				doRun();
			}
			if (player.transform.position.y <= -50.0f) {
				findInRange = true;
				doRun();
			}
		} else {
			if ((int)rb.velocity.y >= 0) {
				higherLower = 1;
				doRun();
			}
			if (player.transform.position.y <= -50.0f) {
				higherLower = -1;
				doRun();
			}
		}
	}

	float yVelMin = -1.0f;
	float yVelMax = -1.0f;
	bool findInRange = false;
	int higherLower = 0;
	void doRun() {
		if (findInRange) {
			if (higherLower == 0) {
				yVelMax = yVelMin;
				yVelMin /= 2.0f;
			}
			float mid = ((yVelMax + yVelMin) / 2.0f);
			int intMid = (int)mid;
			if (higherLower == -1) {
				yVelMax = mid;
			}
			if (higherLower == 1) {
				yVelMin = mid;
			}

			text.text = "Test: See how fast the player needs to move to penetrate a thick wall\n";
			text.text += mid + " is velocity right now";

			
			mid = ((yVelMax + yVelMin) / 2.0f);
			if ((int) mid == intMid) {
				text.text += "Takes " + -mid + " velocity to phase through";
			}

			player.transform.position = new Vector3(0, -mid + 3, player.transform.position.z);
			rb.velocity = new Vector2(0, mid);
		} else {
			text.text = "Test: See how fast the player needs to move to penetrate a thick wall\n";
			text.text += yVelMin + " is vel right now";
			yVelMin *= 2;
			player.transform.position = new Vector3(0, -yVelMin + 3, player.transform.position.z);
			rb.velocity = new Vector2(0, yVelMin);
		}
	}
}