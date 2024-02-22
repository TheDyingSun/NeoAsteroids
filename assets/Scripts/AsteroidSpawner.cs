using UnityEngine;

public class AsteroidSpawner : MonoBehaviour{


    public Asteroid asteroidPrefab;
    public float spawnRate = 2.0f;
    public int spawnAmount = 1;

    public float spawnDistance = 15.0f;

    float trajectoryVariance = 15.0f;


    private void Start() {
        SetDifficulty();
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn() {
        for (int i = 0; i < this.spawnAmount; i++) {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = spawnDirection + this.transform.position;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection / this.spawnDistance);
        }
    }

    private void SetDifficulty() {
        switch (SceneStateManager.currentLevel) {
            case CurrentLevel.IntroStatic:
                spawnRate = 3f;
                break;
            case CurrentLevel.SecondStatic:
                spawnRate = 4f;
                spawnAmount = 2;
                break;
            case CurrentLevel.FourthStatic:
                spawnRate = 3f;
                spawnAmount = 2;
                break;
            case CurrentLevel.ArcadeStatic:
                spawnRate = 3f;
                spawnAmount = 2;
                break;
            default:
                Debug.LogError("Invalid level for this scene!");
                break;
        }
    }
}
