using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int Health;
    public Renderer rend;
    public GameObject DeathEffect;
    Material material;

    IEnumerator FlashOnHit() {
        material.SetFloat("_DelaunayStrength1", 100f);
        material.SetFloat("_DelaunayStrength2", 100f);
        yield return new WaitForSeconds(0.2f);
        material.SetFloat("_DelaunayStrength1", 2.41f);
        material.SetFloat("_DelaunayStrength2", 3.9f);
    }

    private void Awake() {
        material = rend.material;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<ShipBullet>()) {
            Health--;
            StartCoroutine(FlashOnHit());
            if(Health <= 0) {
                Instantiate(DeathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}