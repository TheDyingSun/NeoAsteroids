using UnityEngine;

public class SideScrollingSpawner : MonoBehaviour{


    public Asteroid asteroidPrefab;
    public float spawnRate = 2.0f;
    public int spawnAmount = 1;

    public float spawnDistance = 15.0f;

    // public Vector3 testDirection;
    // public Vector2 testTrajectory;
    // public float testSlope;

    float trajectoryVariance = 15.0f;


    private void Start(){
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);

        //asteroidPrefab = GetComponent<Asteroid>();

    }


    private void Spawn(){
        for (int i = 0; i < this.spawnAmount; i++){
            //Spawn direction can only be right of the player, can't be behind
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            // testDirection = spawnDirection;
            if ((spawnDirection.x + this.transform.position.x) < -4) {
                spawnDirection.x = Mathf.Abs(spawnDirection.x);
                spawnDirection.y = Mathf.Abs(spawnDirection.y);
            }
            Vector3 spawnPoint = spawnDirection + this.transform.position;
            

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
            // testTrajectory = rotation * -spawnDirection;
            // testSlope = testTrajectory.y / testTrajectory.x;


        }


    }


}
