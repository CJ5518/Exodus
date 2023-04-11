using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	class PlayerStateStanding : PlayerStateGrounded {
		//Constructor, called before onEnter
		public PlayerStateStanding(Player plr) : base(plr) {
		}

		public override void onEnter(PlayerState oldState) {
		}
		public override void onExit(PlayerState nextState) {
		}

		public override void update(float dt) {
			moveHorizontal(1.0f);
			player.spriteRenderer.color = Color.blue;
		}
		public override void fixedUpdate() {
			if (player.isGrounded()) {
				if (player.controller.jumpNew) {
					becauseJumped = true;
					jumpStartTime = Time.realtimeSinceStartup;
					player.rigidBody.AddForce(new Vector2(0, player.jumpForce));
					return;
				} else {
					becauseJumped = false;
					
				}
			} else { // Player is NOT grounded
                changeStateTo(new PlayerStateAirborne(player));
				return;
            }
		}
	}
}