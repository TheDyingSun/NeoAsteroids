using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_old : MonoBehaviour
{
    // Start is called before the first frame update


    public Player_old player;

    public float respawnTime = 3.0f;
    public float invincibilityTime = 3.0f;

    public ParticleSystem explosion;

    public int lives = 3;

    public int score = 0;


    public void AsteroidDestroyed(Asteroid_old asteroid){
        if (asteroid.size < 0.75){
            score += 100;
        } else if(asteroid.size < 1){
            score += 50;
        } else {
            score += 10;

        }


        this.explosion.transform.position = asteroid.transform.position; 
        this.explosion.Play();

    }

    public void PlayerDied(){
        this.explosion.transform.position  = this.player.transform.position; 
        this.explosion.Play();
        
        this.lives--;

        if(this.lives <= 0){
            GameOver();

        } else {
            Invoke(nameof(Respawn), respawnTime);

        }

        




    }

    // Update is called once per frame
    void Respawn(){
        this.player.transform.position = Vector3.zero;
        this.player.spriteRenderer.color = this.player.respawnColor;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), invincibilityTime);
        

    }

    private void TurnOnCollisions(){
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
        this.player.spriteRenderer.color = this.player.defaultCol;

    }

    private void GameOver(){
        this.lives = 3;
        this.score = 0;

        Respawn();


    }

}
