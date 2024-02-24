using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 3f;
    [SerializeField] private float maxBonusSpeed = 5f;
    [SerializeField] private float decelerationTime = 1f;
    [SerializeField] private float accelerationTime = 1f;
    [SerializeField] private float baseFoV = 30f;
    [SerializeField] private float maxFoV = 50f;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Projectile poopPrefab;

    private float moveSpeed;

    private void Start()
    {
        moveSpeed = baseMoveSpeed;
    }

    void Update()
    {
        AutoMove();
        AccelerateProcess();
        ShootProcess();
    }

    void AutoMove()
    {
        // Get the direction the player is facing
        Vector3 playerForward = transform.forward;

        // Move the player in their facing direction without fixing Y
        transform.position += playerForward * moveSpeed * Time.deltaTime;
    }

    void AccelerateProcess()
    {
        trail.enabled = false;
        if (Input.GetKey(KeyCode.Space))
        { 
            moveSpeed += accelerationTime * Time.deltaTime;
            trail.enabled = true;
        }
        else if (moveSpeed > baseMoveSpeed)
            moveSpeed -= decelerationTime * Time.deltaTime;
        moveSpeed = Mathf.Clamp(moveSpeed, baseMoveSpeed, baseMoveSpeed + maxBonusSpeed);

        float lerpFactor = (moveSpeed - baseMoveSpeed) / maxBonusSpeed;

        //Hardcode hehe whatevs
        Camera.main.fieldOfView = Mathf.Lerp(baseFoV, maxFoV, lerpFactor);
    }

    void ShootProcess()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Use the current transform's forward direction as the new object's forward direction
            Quaternion spawnRotation = Quaternion.LookRotation(Camera.main.transform.forward);

            // Instantiate the prefab at the calculated position and rotation
            Projectile proj = Instantiate(poopPrefab, spawnPosition.position, spawnRotation);
            proj.Set();
        }
    }
}
