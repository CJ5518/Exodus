using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	public abstract class PlayerStateGrounded : PlayerState {
		public bool becauseJumped = false;
		public float jumpStartTime = -1.0f;

		protected PlayerStateGrounded(Player plr) : base(plr) {
			becauseJumped = false;
			jumpStartTime = -1.0f;
		}
	}
}