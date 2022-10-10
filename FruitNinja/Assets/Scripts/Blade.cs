using UnityEngine;

public class Blade : MonoBehaviour
{
    public Vector3 direction { get; private set; }

    private Camera mainCamera;

    private Collider sliceCollider;
    private TrailRenderer sliceTrail;

    public float sliceForce = 5f;
    public float minSliceVelocity = 0.001f;

    public float bladeNum = 1f;

    private void Awake()
    {
        mainCamera = Camera.main;
        sliceCollider = GetComponent<Collider>();
        bladeNum = FindObjectOfType<ChooseBlade>().getBladeNum();
        ChooseSliceTrail(bladeNum);
        //sliceTrail = GetComponentInChildren<TrailRenderer>();
        StartSlice();
        
    }

  
    private void Update()
    {
        ContinueSlice();
    }

    private void StartSlice()
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f;
        transform.position = position;

        sliceCollider.enabled = true;
        sliceTrail.enabled = true;
        sliceTrail.Clear();
    }

    private void ContinueSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;;
        direction = newPosition - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;
        
        sliceCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }

    public void ChooseSliceTrail(float num)
    {
        //awake tail based on number
        //sliceTrail = ...
    }

}

