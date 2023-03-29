using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	class PlayerStateStanding : PlayerState {
		//Constructor, called before onEnter
		public PlayerStateStanding(Player plr) : base(plr) {
			
		}

		public override void onEnter(PlayerState oldState) {

		}
		public override void onExit(PlayerState nextState) {

		}

		public override void update(float dt) {
			moveHorizontal(1.0f);
			if (player.isGrounded()) {
				if (player.controller.jumpNew) {
					player.rigidBody.AddForce(new Vector2(0, 500.0f));
				}
			} else { // Player is NOT grounded
                changeStateTo(new PlayerStateAirborne(player));
            }
		}
		public override void fixedUpdate() {

		}
	}
}