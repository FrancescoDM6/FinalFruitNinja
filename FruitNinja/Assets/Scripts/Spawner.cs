using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;

    public float torque;
    public GameObject bomb;
    public bool isBomb = false;

    public GameObject bonusBerry;
    public bool isBonusBerry = false;
    public float bonusBerryChance = 0.01f;//the x2peach
    public GameObject bonusBerryPrefab;

    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;

    [Range(0f,1f)]

    public float bombChance = 0.05f;
    public GameObject blueberryPrefab;
    public float blueberryChance = 0.0f;

    public float minSpawnDelay = .5f;
    public float maxSpawnDelay = 1.5f;

    public float minAngle = -15f;
    public float maxAngle = 15f;

    public float minForce = 18f;
    public float maxForce = 24f;

    public float maxLifetime = 4f;

    public float timer;
    public float randomNum;


    private void Awake()
    {
        timer = 0f;
        spawnArea = GetComponent<Collider>();
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer%300 >= 1)//Only increase bomb chance for 5 minutes strait
        {
            IncreaseBombChance();
        }
        bonusBerryChance = bombChance / 4;
    }

    public void IncreaseBombChance()
    {
        if (timer%60 <= .1)//every ~60 seconds
        {
            bombChance += 0.05f;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            GameObject prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
            randomNum = Random.value;

            if (randomNum < blueberryChance && randomNum > bombChance)
            {
                prefab = blueberryPrefab;
                
            } else if (randomNum < bombChance && randomNum > bonusBerryChance){
                prefab = bombPrefab;
                isBomb = true;
            } else if (randomNum < bonusBerryChance){
                prefab = bonusBerryPrefab;
                isBonusBerry = true;
            }

            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
            
            GameObject fruit = Instantiate(prefab, position, rotation);

            if(isBomb == true)
            {
                Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
                float turn = Input.GetAxis("Horizontal");
                bombRb.AddTorque(transform.up * torque * turn);

                FindObjectOfType<PlayAudio>().Sizzle(true);
                isBomb = false;
            }
            
           /* if(isBomb == true){
                GetComponent<AudioSource>().Play();
            }*/

            // if(isBonusBerry == true){

            // }
            

            Destroy(fruit, maxLifetime);

            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            
        }
    }
}
