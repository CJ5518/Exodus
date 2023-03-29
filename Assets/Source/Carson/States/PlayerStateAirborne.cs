using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	class PlayerStateAirborne : PlayerState {
		//Constructor, called before onEnter
		public PlayerStateAirborne(Player plr) : base(plr) {

		}

		public override void onEnter(PlayerState oldState) {
			
		}
		public override void onExit(PlayerState nextState) {
			
		}

		public override void update(float dt) {
			moveHorizontal(1.0f);
			Debug.Log("AIR");
		}
		public override void fixedUpdate() {
			if (player.isFalling()) {
				player.rigidBody.AddForce(new Vector2(0, -20.0f));
			}

			if (player.isGrounded()) {
				changeStateTo(new PlayerStateStanding(player));
			}
		}
	}
}