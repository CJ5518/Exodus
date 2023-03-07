using System;
using System.Collections.Generic;
using UnityEngine;

//Singleton class to get the player object
public static class PlayerSingleton {
	static Player m_Player;

	//Public getter
	public static Player Player {
		get {
			if (m_Player != null) {
				return m_Player;
			} else {
				try {
					m_Player = GameObject.FindWithTag("Player").GetComponent<Player>();

				} catch (Exception e) {
					throw new Exception("Got an exception while finding the player: " + e.Message);
				}
				return m_Player;
			}
		}
	}
}
