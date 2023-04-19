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

	//Health tests
	[Test]
	public void CanResetHealthTest() {
		PlayerSingleton.Player.resetHealth();
		Assert.AreEqual(PlayerSingleton.Player.health, 100);
	}
	[Test]
	public void CanEditHealthTest() {
		PlayerSingleton.Player.resetHealth();
		PlayerSingleton.Player.dealDamage(20);
		Assert.AreEqual(PlayerSingleton.Player.health, 80);
		PlayerSingleton.Player.dealDamage(40);
		Assert.AreEqual(PlayerSingleton.Player.health, 40);
		PlayerSingleton.Player.dealDamage(-20);
		Assert.AreEqual(PlayerSingleton.Player.health, 60);
	}

	private int timesInvoked = 0;
	public void onDeath() {
		timesInvoked++;
	}
	[Test]
	public void OnDeathIsInvokedTest() {
		PlayerSingleton.Player.resetHealth();
		PlayerSingleton.Player.onDeath.AddListener(onDeath);
		PlayerSingleton.Player.dealDamage(PlayerSingleton.Player.health);
		Assert.AreEqual(timesInvoked, 1);
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
		yield return null;yield return null;
		yield return null;yield return null;
		yield return null;yield return null;
		yield return null;yield return null;
		yield return null;yield return null;
		yield return null;yield return null;
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
