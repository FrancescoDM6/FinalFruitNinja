using UnityEngine;

public class Blade : MonoBehaviour
{
    public Vector3 direction { get; private set; }

    private Camera mainCamera;

    private Collider sliceCollider;
    private TrailRenderer sliceTrail;

    public float sliceForce = 5f;
    public float minSliceVelocity = 0.001f;

    //public AudioSource Swordswipe1;

    //private bool slicing;

    private void Awake()
    {
        
        mainCamera = Camera.main;
        sliceCollider = GetComponent<Collider>();
        sliceTrail = GetComponentInChildren<TrailRenderer>();
        StartSlice();
        
    }

    /*private void OnEnable()
    {
        StartSlice();
    }

    private void OnDisable()
    {
        StopSlice();
    }*/

    private void Update()
    {
        ContinueSlice();


        // FindObjectOfType<PlayAudio>().Swipe(true);//plays swipe when hitting fruit
        /* if (Input.GetMouseButtonDown(0))
         {

             StartSlice();
             // GetComponent<AudioSource>().Play();
         }
         else if (Input.GetMouseButtonUp(0))
         {
             FindObjectOfType<PlayAudio>().Swipe(false);
             StopSlice();
         }
         else if (slicing)
         {
             FindObjectOfType<PlayAudio>().Swipe(true);
             ContinueSlice();
             // Swordswipe1.Play();
         }*/
    }

    private void StartSlice()
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f;
        transform.position = position;

        //slicing = true;
        sliceCollider.enabled = true;
        sliceTrail.enabled = true;
        sliceTrail.Clear();
    }

    /*private void StopSlice()
    {
        slicing = false;
        sliceCollider.enabled = false;
        sliceTrail.enabled = false;

    }*/

    private void ContinueSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        // Vector3 oldDir = direction;
        direction = newPosition - transform.position;

        // float angle = Vector3.Angle(direction, oldDir);
        // if (angle >= 90.0f){
        //     FindObjectOfType<PlayAudio>().Swipe(true);
        // }
        float velocity = direction.magnitude / Time.deltaTime;
        
        sliceCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;

        
    }

}

