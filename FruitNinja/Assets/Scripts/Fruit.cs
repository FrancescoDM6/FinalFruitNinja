using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody fruitRB;
    private Collider fruitCol;
    private ParticleSystem juiceParticleEffect;

    public int numSliced;

    public int points = 1;

    public int multiplier;
    public bool bb = false;

    public int timer;
   // public float timeStamp;

        private void Awake()
    {
       // timer = FindObjectOfType<Spawner>().timer;
        //timer = 0f;
        numSliced = 0;
        fruitRB = GetComponent<Rigidbody>();
        fruitCol = GetComponent<Collider>();
        juiceParticleEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {

        // bb = false;
        // if (ActivateBonus() == false){
        //     GetPoint(1);
        // } else if (ActivateBonus() == true){
        //     GetPoint(multiplier);
        // }

        GetPoint(multiplier);

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
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
            numSliced++;
        }
    }

    private void GetPoint(int mult){
        if (mult == 2)
        {
            print("2");
            FindObjectOfType<PlayAudio>().Wait(20f);
            print("1");
            
        }
        multiplier = mult;

        points = points*multiplier;
        FindObjectOfType<GameManager>().IncreaseScore(points);

        //multiplier = 1;
    }



}
