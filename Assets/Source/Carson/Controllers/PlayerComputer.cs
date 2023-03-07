using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	public class PlayerComputer : PlayerController {

		public new float horizontal {
			get {
				return m_horizontal;
			}
			set {
				m_horizontal = value;
			}
		}

		public new bool vertical {
			get {
				return m_vertical;
			}
			set {
				m_vertical = value;
			}
		}

		public override void handleInput() {
		}
	}
}