using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using cj;

public class CarsonBoundaryTests {

	[UnitySetUp]
	public IEnumerator SetUp() {
		SceneManager.LoadScene("Source/Common/Scenes/SampleScene");
		//Wait for the scene to load
		while (!SceneManager.GetActiveScene().name.Contains("SampleScene")) {
			yield return null;
		}
	}

	//Can we get the player using the Player Singleton?
	[Test]
	public void CanGetPlayerTest() {
		Assert.NotNull(PlayerSingleton.Player);
	}

	//Can the player move left and right properly?
	[UnityTest]
	public IEnumerator CanMovePlayerTest() {
		//Arrange
		Player player = PlayerSingleton.Player;
		PlayerComputer controller = new PlayerComputer();
		player.controller = controller;

		//Act
		controller.pressHorizontal(1);

		float oldX = player.transform.position.x;
		//Wait a few frames
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		Assert.IsTrue(player.transform.position.x > oldX);

		//Act (Again)
		controller.pressHorizontal(-1);

		oldX = player.transform.position.x;
		//Wait a few frames
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		Assert.IsTrue(player.transform.position.x < oldX);
	}
}
