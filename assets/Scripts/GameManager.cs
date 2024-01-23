using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public PauseScreen pausescreen;
    public ConfirmExitScreen exitScreen;

    public float respawnTime = 3.0f;
    public float invincibilityTime = 3.0f;

    public ParticleSystem explosion;

    public int lives = 3;

    public int score = 0;

    private void Update() {
        if (Input.GetKey("escape")) {
            //Show Pause Menu
            
        }
    }

    private void ExitToMainMenu() {
        SceneManager.LoadScene(sceneName:"Main Menu");

    }

    public void AsteroidDestroyed(Asteroid asteroid){
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

        if(this.lives <= 0){ GameOver(); } 
        else { Respawn(); }
    }

    // Update is called once per frame
    private void Respawn(){
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        this.player.animator.SetBool("invincible", true);
        Invoke(nameof(TurnOnCollisions), invincibilityTime);
    }

    private void TurnOnCollisions(){
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
        this.player.animator.SetBool("invincible", false);
    }

    private void GameOver(){
        this.lives = 3;
        this.score = 0;

        Respawn();
    }

}
