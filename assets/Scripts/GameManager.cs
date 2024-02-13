using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Player player;
    public InGame inGameInterface;
    public ParticleSystem explosion;
    public Fadescreen fadescreen;

    public float respawnTime = 3.0f;
    public float invincibilityTime = 3.0f;
    public float gameEndTime = 2.0f;
    public int lives = 3;
    public int score = 0;
    

    public enum WinCondition {Number, Time, Score};
    public WinCondition winCondition = WinCondition.Number;
    public int winAmount = 20;

    private int asteroidsDestroyed = 0;
    private bool firstFrame;
    private void Start() {
        inGameInterface.updateWinCondition(winCondition);
        inGameInterface.updateWinProgress(winAmount.ToString("D"));
        fadescreen.fadeIn();
    }

    private void ExitToMainMenu() {
        SceneManager.LoadScene(sceneName:"MainMenu");
    }

    public void AsteroidDestroyed(Asteroid asteroid){
        if (asteroid.size < 0.75){
            score += 200;
        } else if(asteroid.size < 1){
            score += 150;
        } else {
            score += 100;
        }

        this.explosion.transform.position = asteroid.transform.position; 
        this.explosion.Play();
        this.inGameInterface.updateScore(score);
        this.asteroidsDestroyed++;

        if (winCondition == WinCondition.Number) {
            int asteroidsLeft = this.winAmount - this.asteroidsDestroyed;
            this.inGameInterface.updateWinProgress(asteroidsLeft.ToString("D"));

            if (asteroidsDestroyed >= winAmount) {
                // update interface
                if (fadescreen) { fadescreen.fadeOut(); }
                Invoke(nameof(GameOver), gameEndTime);
            }
        }
    }

    public void PlayerDied(){
        if (this.lives <= 0){ Invoke(nameof(GameOver), gameEndTime); } 
        else { Respawn(); }

        this.explosion.transform.position  = this.player.transform.position; 
        this.explosion.Play();
        this.lives--;

        inGameInterface.updateLives(this.lives);
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
        this.lives = 0;
        this.score = 0;
        inGameInterface.updateLives(this.lives);
        inGameInterface.updateScore(this.score);
        this.player.gameObject.SetActive(false);
        ExitToMainMenu();
    }

}
