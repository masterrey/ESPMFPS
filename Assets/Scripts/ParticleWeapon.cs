using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeapon : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            particleSystem.Emit(1);
        }
       
        
    }
}
