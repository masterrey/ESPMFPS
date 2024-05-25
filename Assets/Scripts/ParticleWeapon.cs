using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeapon : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float damage = 10f;

    public GameObject weaponMesh;
    Vector3 originalPosition;

    public AudioSource audioSource;

    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = weaponMesh.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetButtonDown("Fire1"))
        {
            particleSystem.Emit(1);
            light.enabled = true;
            Invoke("DisableFlash", 0.05f);
            //recoil
            weaponMesh.transform.localPosition = originalPosition + new Vector3(0, 0, -0.2f);
            audioSource.pitch = Random.Range(0.2f, 0.3f);
            audioSource.Play();
        }
        weaponMesh.transform.localPosition = Vector3.Lerp(weaponMesh.transform.localPosition, originalPosition, Time.deltaTime * 10f);
    }

    void DisableFlash()
    {
        light.enabled = false;
       
    }
}
