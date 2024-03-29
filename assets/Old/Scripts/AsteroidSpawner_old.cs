using UnityEngine;

public class AsteroidSpawner_old : MonoBehaviour{


    public Asteroid_old asteroidPrefab;
    public float spawnRate = 2.0f;
    public int spawnAmount = 1;

    public float spawnDistance = 15.0f;

    float trajectoryVariance = 15.0f;


    private void Start(){
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);

        //asteroidPrefab = GetComponent<Asteroid>();

    }


    private void Spawn(){
        for (int i = 0; i < this.spawnAmount; i++){
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = spawnDirection + this.transform.position;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid_old asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);


        }


    }


}
