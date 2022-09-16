using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;

    public float torque;
    public GameObject bomb;
    public bool isBomb = false;

    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;

    [Range(0f,1f)]

    public float bombChance = 0.05f;
    public GameObject blueberryPrefab;
    public float blueberryChance = 0.1f;

    public float minSpawnDelay = .5f;
    public float maxSpawnDelay = 1.5f;

    public float minAngle = -15f;
    public float maxAngle = 15f;

    public float minForce = 18f;
    public float maxForce = 24f;

    public float maxLifetime = 4f;


    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
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

            if (Random.value < blueberryChance)
            {
                prefab = blueberryPrefab;
                if (Random.value < bombChance)
                {
                    prefab = bombPrefab;
                    isBomb = true;
                }
                
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
            
            if(isBomb == true){
                GetComponent<AudioSource>().Play();
            }
            

            Destroy(fruit, maxLifetime);

            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            
        }
    }
}
