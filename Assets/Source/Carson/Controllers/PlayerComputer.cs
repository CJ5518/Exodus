using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace cj {
	public class PlayerComputer : PlayerController {
		private UnityEvent m_gatherInputEvent = new UnityEvent();

		// This event will be invoked when we want to gather input
		public UnityEvent gatherInputEvent {
			get {
				return m_gatherInputEvent;
			}
		}
		
		// Called by the player
		public override void gatherInput() {
			resetNews();
			m_gatherInputEvent.Invoke();
		}
	}
}