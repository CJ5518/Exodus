using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cj {
	public abstract class PlayerController {

		// Input params - basic
		protected int m_horizontal = 0;
		protected int m_vertical = 0;
		protected bool m_jump = false;
		protected bool m_horizontalNew = false;
		protected bool m_verticalNew = false;
		protected bool m_jumpNew = false;


		// Input params but in getter form
		public int horizontal {
			get {
				return m_horizontal;
			}
		}
		public int vertical {
			get {
				return m_vertical;
			}
		}
		public bool jump {
			get {
				return m_jump;
			}
		}
		public bool horizontalNew {
			get {
				return m_horizontalNew;
			}
		}
		public bool verticalNew {
			get {
				return m_verticalNew;
			}
		}
		public bool jumpNew {
			get {
				return m_jumpNew;
			}
		}

		// Reset all of the inputs to defaults, i.e nothing
		public void resetAllButtons() {
			m_horizontal = 0;
			m_vertical = 0;
			m_jump = false;
			m_horizontalNew = false;
			m_verticalNew = false;
			m_jumpNew = false;
		}

		// Reset all of the "news"
		public void resetNews() {
			m_verticalNew = false;
			m_horizontalNew = false;
			m_jumpNew = false;
		}


		// Functions to simplify the input gathering process
		public void pressHorizontal(int direction) {
			m_horizontal = direction;
			m_horizontalNew = true;
		}

		public void releaseHorizontal(int direction) {
			m_horizontal = 0;
		}

		public void pressVertical(int direction) {
			m_vertical = direction;
			m_verticalNew = true;
		}

		public void releaseVertical(int direction) {
			m_vertical = 0;
		}

		public void pressJump() {
			m_jumpNew = true;
			m_jump = true;
		}

		public void releaseJump() {
			m_jump = false;
		}

		// Function called by the player, asks the underlying controller to tell the player what to do that frame
		public abstract void gatherInput();
	}
}