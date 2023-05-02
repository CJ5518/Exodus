using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	public abstract class PlayerState {
		// The player object common to all states
		protected Player player;

		// Common function, all states need the player
		protected PlayerState(Player plr) {
			player = plr;
		}
		
		// Common function, most states move horizontally somehow
		protected void moveHorizontal(float amount) {
			Vector2 newForce = new Vector2();
			newForce.x = player.controller.horizontal;
			player.rigidBody.AddForce(newForce * 200 * amount);
			if (player.controller.horizontal == 1) {
				player.mosesSprite.flipX = true;
			} else if (player.controller.horizontal == -1) {
				player.mosesSprite.flipX = false;
			}
		}

		// Functions called when a state is formally entered/exited
		public abstract void onEnter(PlayerState oldState);
		public abstract void onExit(PlayerState nextState);

		// Function to change the player state
		public void changeStateTo(PlayerState newState) {
			this.onExit(newState);
			player.playerState = newState;
			newState.onEnter(this);
		}

		// Functions called in the Player version of the Unity callbacks
		public abstract void update(float dt);
		public abstract void fixedUpdate();

		// Data for the collisions
		ContactPoint2D[] contactPoints;

		// Helper function to deal with the contact points array
		public void populateContactPoints(Collision2D collision)  {
			if (contactPoints == null || contactPoints.Length < collision.contactCount) {
				contactPoints = new ContactPoint2D[collision.contactCount + 1];
			}
			collision.GetContacts(contactPoints);
		}

		// Functions called by player concerning collisions
		// Declared as virtual, if you make a new version in the PlayerState___ then call base.onColl___
		public virtual void onCollisionEnter2D(Collision2D collision) {
			
		}
		public virtual void onCollisionStay2D(Collision2D collision) {

		}
		public virtual void onCollisionExit2D(Collision2D collision) {
			
		}
	}
}