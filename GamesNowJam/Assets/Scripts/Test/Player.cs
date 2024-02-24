using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Projectile poopPrefab;
    [SerializeField] private Slider poopMeter;

    [Header("Game Properties")]
    [SerializeField] private float poopCost = 10f;
    [SerializeField] private float poopRewardedPerTreat = 30f;
    [SerializeField] private float maxPoop = 100f;

    [Header("Movement Properties")]
    [SerializeField] private float baseMoveSpeed = 3f;
    [SerializeField] private float maxBonusSpeed = 5f;
    [SerializeField] private float timeToReturnToOriginalSpeed = 1f;
    [SerializeField] private float timeToReachMaxSpeed = 1f;
    [SerializeField] private float defaultFoV = 30f;
    [SerializeField] private float maxSpeedFoV = 50f;
    private float currentPoopCount;

    private float moveSpeed;

    private void Start()
    {
        moveSpeed = baseMoveSpeed;
        currentPoopCount = maxPoop;
    }

    void Update()
    {
        AutoMove();
        AccelerateProcess();
        ShootProcess();
        UpdateUI();
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
            moveSpeed += timeToReachMaxSpeed * Time.deltaTime;
            trail.enabled = true;
        }
        else if (moveSpeed > baseMoveSpeed)
            moveSpeed -= timeToReturnToOriginalSpeed * Time.deltaTime;
        moveSpeed = Mathf.Clamp(moveSpeed, baseMoveSpeed, baseMoveSpeed + maxBonusSpeed);

        float lerpFactor = (moveSpeed - baseMoveSpeed) / maxBonusSpeed;

        //Hardcode hehe whatevs
        Camera.main.fieldOfView = Mathf.Lerp(defaultFoV, maxSpeedFoV, lerpFactor);
    }

    void ShootProcess()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentPoopCount >= poopCost)
        {
            // Use the current transform's forward direction as the new object's forward direction
            Quaternion spawnRotation = Quaternion.LookRotation(Camera.main.transform.forward);

            // Instantiate the prefab at the calculated position and rotation
            Projectile proj = Instantiate(poopPrefab, spawnPosition.position, spawnRotation);
            proj.Set();

            currentPoopCount -= poopCost;
        }
    }

    void UpdateUI()
    {
        poopMeter.value = currentPoopCount / maxPoop;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Treats")
            currentPoopCount = Mathf.Clamp(currentPoopCount + poopRewardedPerTreat, 0f, maxPoop);
        else if (other.gameObject.tag == "Enemy")
        {
            //Player died
            Debug.Log("Player lost - Do Something");
        }
    }
}
