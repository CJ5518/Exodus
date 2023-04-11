using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	class PlayerStateAirborne : PlayerState {
		bool risingJump = false;
		float jumpStartTime = 0.0f;
		//Constructor, called before onEnter
		public PlayerStateAirborne(Player plr) : base(plr) {
			risingJump = false;
		}

		public override void onEnter(PlayerState oldState) {
			if (oldState is PlayerStateGrounded) {
				PlayerStateGrounded oldGrounded = oldState as PlayerStateGrounded;
				risingJump = oldGrounded.becauseJumped;
				jumpStartTime = oldGrounded.jumpStartTime;
			}
		}
		public override void onExit(PlayerState nextState) {
		}

		public override void update(float dt) {
			moveHorizontal(1.0f);
			player.spriteRenderer.color = Color.red;

			if (!player.controller.jump) {
				risingJump = false;
			}
		}
		public override void fixedUpdate() {
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
				Debug.Log("Switching to standing from airborne because we are grounded ");
				changeStateTo(new PlayerStateStanding(player));
				return;
			}
		}
	}
}