using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	class PlayerStateAirborne : PlayerState {
		//Constructor, called before onEnter
		public PlayerStateAirborne(Player plr) : base(plr) {

		}

		public override void onEnter(PlayerState oldState) {
			Debug.Log("CJ: onEnter: Entered Airborne");
		}
		public override void onExit(PlayerState nextState) {
			Debug.Log("CJ: onExit: Entered Airborne");
		}

		public override void update(float dt) {

		}
		public override void fixedUpdate() {
			moveHorizontal(1.0f);
		}
	}
}