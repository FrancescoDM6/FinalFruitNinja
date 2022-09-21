using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_OLD : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody fruitRB;
    private Collider fruitCol;
    private ParticleSystem juiceParticleEffect;

    public int points = 1;

    private void Awake()
    {
        fruitRB = GetComponent<Rigidbody>();
        fruitCol = GetComponent<Collider>();
        juiceParticleEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        FindObjectOfType<GameManager_OLD>().IncreaseScore(points);

        whole.SetActive(false); ;
        sliced.SetActive(true);

        fruitCol.enabled = false;
        juiceParticleEffect.Play();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
   
    
        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitRB.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade_OLD blade = other.GetComponent<Blade_OLD>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }

}
