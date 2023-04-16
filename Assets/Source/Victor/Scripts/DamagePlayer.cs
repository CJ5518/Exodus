using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            PlayerSingleton.Player.dealDamage(damage);
        }
    }
}