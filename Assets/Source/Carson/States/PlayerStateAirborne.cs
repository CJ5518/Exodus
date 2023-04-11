using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	class PlayerStateAirborne : PlayerState {
		// The things that which are necessary for a walljump to occur
		private struct wallJumpConditions {
			int contactTimer;
			float otherDirectionTime;
		}

		// An array of size two that helps check if we can wall jump off of walls at either side
		private wallJumpConditions[] possibleWallJumps;

		// Variables concerned with the rising jump
		bool risingJump = false;
		float jumpStartTime = 0.0f;
		//Constructor, called before onEnter
		public PlayerStateAirborne(Player plr) : base(plr) {
			risingJump = false;
			possibleWallJumps = new wallJumpConditions[2];
		}

		public override void onEnter(PlayerState oldState) {
			if (oldState is PlayerStateGrounded) {
				PlayerStateGrounded oldGrounded = oldState as PlayerStateGrounded;
				risingJump = oldGrounded.becauseJumped;
				jumpStartTime = oldGrounded.jumpStartTime;
			}
			player.spriteRenderer.color = Color.red;
		}
		public override void onExit(PlayerState nextState) {
		}

		public override void update(float dt) {
			moveHorizontal(1.0f);

			if (!player.controller.jump) {
				risingJump = false;
			}

			if (risingJump && player.isTouchingCeiling()) {
				risingJump = false;
			}

			if (player.controller.jumpNew) {
				int wall = player.isTouchingWall(0.4f);
				if (wall != 0 && -player.controller.horizontal == wall) {
					risingJump = true;
					player.rigidBody.velocity = new Vector2(player.rigidBody.velocity.x, 0);
					jumpStartTime = Time.realtimeSinceStartup;
				}
			}
		}
		public override void fixedUpdate() {
			// Walljump section
			if (player.isTouchingWall() != 0) {
				
			}


			// Handles falling and changing state to grounded
			if (player.isFalling()) {
				player.rigidBody.AddForce(new Vector2(0, player.fallForce));
			} else {
			}

			if (risingJump && player.controller.jump) {
				float timeFactor = (Time.realtimeSinceStartup - jumpStartTime) / player.maxJumpRiseTime;
				if (timeFactor >= 1.0f) {
					risingJump = false;
					return;
				}
				player.rigidBody.AddForce(new Vector2(0, player.jumpForce) * (1.0f-Mathf.Sqrt(timeFactor)));
			}

			if (player.isGrounded()) {
				changeStateTo(new PlayerStateStanding(player));
				return;
			}
		}
		// Go from a direction (-1 or 1) and get an array index (0 or 1)
		private int decodeDirection(int dir) {
			return (dir + 1) / 2;
		}
	}
}