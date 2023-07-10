using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed = 3f;
    public int maxHealth = 5;
    public GameObject bulletPrefab;
    public static int numberOfClones=1;
    private int currentHealth;
    private Transform player;
    private float spawnDelay = 2f;
    private Vector3 currentDirection;
    public float raycastDistance = 2f;
    public Slider healthbar;
    private bool MaxAttend=false;

    private void Start()
    {
        currentHealth = maxHealth;
        // Start with a random movement direction
    currentDirection = Random.insideUnitSphere;
    currentDirection.y = 0f;

        InvokeRepeating("SpawnEnemy", spawnDelay, spawnDelay);
    }

    private void Update()
    {
        healthbar.value=currentHealth;
        // Move towards the player
         // Move in the current direction
    transform.Translate(currentDirection * movementSpeed * Time.deltaTime);
    if(numberOfClones==10){
        MaxAttend=true;
    }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
             Debug.Log("touch it ");
        }
        if(other.CompareTag("Wall")){
            Debug.Log("collided with wall");
            // Check for obstacles
            Vector3 invertedVector = currentDirection * -1;
            currentDirection = invertedVector;
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Add death effects if needed
        numberOfClones -=1;
        Debug.Log(numberOfClones);
        if(numberOfClones==0){
        Debug.Log("change the scene");
         SceneManager.LoadScene("BobRoomAfterBattle");
    }
        Destroy(gameObject);
    }

    private void SpawnEnemy()
    {
        Debug.Log(numberOfClones);
        if(!MaxAttend){
            if (numberOfClones < 4)
            {
                numberOfClones++;
                Instantiate(gameObject, transform.position, Quaternion.identity);
                Invoke("ResetSpawnDelay", 0.5f);
            }
            else
            {
                numberOfClones++;
                Instantiate(gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    private void ResetSpawnDelay()
    {
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", spawnDelay*2, spawnDelay*2);
    }
}
