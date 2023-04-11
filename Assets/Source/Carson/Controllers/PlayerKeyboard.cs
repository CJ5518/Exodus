using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	public class PlayerKeyboard : PlayerController {
		public override void gatherInput() {
			resetAllButtons();

			// Button holds
			// Tfw you find out about Input.GetAxis days too late
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
				m_horizontal = -1;
			}
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
				m_horizontal = 1;
			}
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
				m_vertical = 1;
			}
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
				m_vertical = -1;
			}
			if (Input.GetKey(KeyCode.Space)) {
				m_jump = true;
			}

			// Button news
			if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
				m_horizontalNew = true;
			}
			if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
				m_horizontalNew = true;
			}
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
				m_verticalNew = true;
			}
			if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
				m_verticalNew = true;
			}
			if (Input.GetKeyDown(KeyCode.Space)) {
				m_jumpNew = true;
			}
		}
	}
}