using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	class PlayerStateCrouch : PlayerStateGrounded {
		//Constructor, called before onEnter
		public PlayerStateCrouch(Player plr) : base(plr) {
			
		}

		public override void onEnter(PlayerState oldState) {
			player.transform.localScale = player.crouchScale;
			player.transform.position -= new Vector3(0,(player.normalScale - player.crouchScale).y / 2.0f,0);
		}
		public override void onExit(PlayerState nextState) {
			player.transform.localScale = player.normalScale;
			player.transform.position += new Vector3(0,(player.normalScale - player.crouchScale).y / 2.0f,0);
		}

		public override void update(float dt) {
			// If player is NOT holding down
			if (player.controller.vertical != -1) {
				// Then go to standing state
				changeStateTo(new PlayerStateStanding(player));
				return;
			}
			checkJumpsAndSuchUpdate();
		}
		public override void fixedUpdate() {
			checkJumpsAndSuchFixed();
		}
	}
}