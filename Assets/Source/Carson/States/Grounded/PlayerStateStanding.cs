using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	// This class has over time become standing/running because the two are so similar
	class PlayerStateStanding : PlayerStateGrounded {
		// Constructor, called before onEnter
		public PlayerStateStanding(Player plr) : base(plr) {
		}

		public override void onEnter(PlayerState oldState) {
			player.spriteRenderer.color = Color.blue;
		}
		public override void onExit(PlayerState nextState) {
		}

		public override void update(float dt) {
			// If player holds down
			if (player.controller.vertical == -1) {
				// Then go to crouching state
				changeStateTo(new PlayerStateCrouch(player));
				return;
			}
			checkJumpsAndSuchUpdate();
		}
		public override void fixedUpdate() {
			moveHorizontal(1.0f);
			checkJumpsAndSuchFixed();
		}
	}
}