using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	public class PlayerKeyboard : PlayerController {
		public override void handleInput() {
			m_horizontal = 0.0f;
			m_vertical = false;
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
				m_horizontal = -1.0f;
			}
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
				m_horizontal = 1.0f;
			}
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
				m_vertical = true;
			}
		}
	}
}