using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	public abstract class PlayerStateGrounded : PlayerState {
		// Variables passed to PlayerStateAirborne telling it if we jumped or not
		public bool becauseJumped = false;
		public float jumpStartTime = -1.0f;

		private bool shouldJump = false;

		static AudioClip jumpSound;

		static PlayerStateGrounded() {
			jumpSound = Resources.Load<AudioClip>("jumpSound");
		}

		// Constructor, initialize member variables
		protected PlayerStateGrounded(Player plr) : base(plr) {
			becauseJumped = false;
			jumpStartTime = -1.0f;
			shouldJump = false;
		}

		// Reads user input to check if the player should jump
		// Also lets the user hold space to jump which I'm not sure was a feature until now
		protected void checkJumpsAndSuchUpdate() {
			if (player.controller.jump) {
				shouldJump = true;
			}
		}
		
		// Check if the player is trying to jump or falls off a platform
		// Returns true if we call the changeStateTo function
		protected bool checkJumpsAndSuchFixed() {
			if (player.isGrounded()) {
				if (shouldJump) {
					becauseJumped = true;
					jumpStartTime = Time.realtimeSinceStartup;
					player.audioSource.PlayOneShot(jumpSound);
					player.rigidBody.AddForce(new Vector2(0, player.jumpForce));
				} else {
					becauseJumped = false;
				}
				shouldJump = false;
			} else { // Player is NOT grounded
				changeStateTo(new PlayerStateAirborne(player));
				return true;
			}
			return false;
		}
	}
}