using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	public abstract class PlayerController {
		protected float m_horizontal = 0.0f;
		protected bool m_vertical = false;
		public float horizontal {
			get {
				return m_horizontal;
			}
		}

		public bool vertical {
			get {
				return m_vertical;
			}
		}

		public abstract void handleInput();
	}
}