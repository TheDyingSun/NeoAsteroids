using UnityEngine;

public class SideScrollingSpawner : MonoBehaviour{


    public Asteroid asteroidPrefab;
    public float spawnRate = 2.0f;

    public float spawnDistance = 15.0f;
    public float spawnSpeed = 50.0f;

    public float spawnAngleVariance = 45.0f;
    public float trajectoryAngleVariance = 10.0f;


    private void Start(){
        SetDifficulty();
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn() {
        float spawnAngle = Random.Range(-spawnAngleVariance, spawnAngleVariance);
        Vector3 spawnLocation = Quaternion.Euler(0f, 0f, spawnAngle) * new Vector3(spawnDistance, 0f, 0f);
        spawnLocation += new Vector3(-5f, 0f, 0f); // make asteroids target player instead of center
        
        float trajectoryVariance = Random.Range(-trajectoryAngleVariance, trajectoryAngleVariance);
        Vector3 trajectory = Quaternion.Euler(0f, 0f, spawnAngle + trajectoryVariance) * new Vector3(-1f, 0f, 0f);

        Asteroid asteroid = Instantiate(asteroidPrefab, spawnLocation, Quaternion.identity);
        asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
        asteroid.speed = spawnSpeed;
        
        asteroid.SetTrajectory(trajectory);
    }

    private void SetDifficulty() {
        switch (SceneStateManager.currentLevel) {
            case CurrentLevel.FirstSideScroll:
                spawnRate = 3f;
                break;
            case CurrentLevel.ThirdSideScroll:
                spawnRate = 2f;
                break;
            default:
                Debug.LogError("Invalid level for this scene!");
                break;
        }
    }
}
