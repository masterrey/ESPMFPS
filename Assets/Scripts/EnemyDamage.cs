using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float health = 100f;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method is called when the player's weapon hits an enemy
    public void OnParticleCollision(GameObject other)
    {
        //make the enemy blink red when hit
        mat.color = Color.red;
        Invoke("ResetMaterial", 0.1f);

        health -= 10f;
        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }

    void ResetMaterial()
    {
        mat.color = Color.white;
    }
}
