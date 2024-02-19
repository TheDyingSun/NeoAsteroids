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
    public Planet planet;

    public float respawnTime = 3.0f;
    public float invincibilityTime = 3.0f;
    public float gameEndTime = 2.0f;
    public int lives = 3;
    public int score = 0;
    

    public enum WinCondition {Number, Time, Score};
    public WinCondition winCondition = WinCondition.Number;
    public int winAmount = 20;
    private int minutesRemaining, secondsRemaining;
    private bool signalledPlanet = false;

    private int asteroidsDestroyed = 0;
    private bool firstFrame;
    private float timeRemaining;

    private void Start() {
        if (winCondition == WinCondition.Time) timeRemaining = (float) winAmount;
        if (winCondition == WinCondition.Number || winCondition == WinCondition.Score) {
            planet.setStatic(1);
        }

        inGameInterface.updateWinCondition(winCondition);
        inGameInterface.updateWinProgress(winAmount.ToString("D"));
        if (fadescreen) fadescreen.fadeIn();
    }

    private void ExitToMainMenu() {
        SceneManager.LoadScene(sceneName:"MainMenu");
    }

    public void AsteroidDestroyed(Asteroid asteroid){
        if (asteroid.size < 0.75) {
            score += 200;
        } else if(asteroid.size < 1) {
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

            if (asteroidsDestroyed >= winAmount) GameOver();
        }
    }

    public void PlayerDied(){
        this.explosion.transform.position  = this.player.transform.position; 
        this.explosion.Play();
        this.lives--;

        inGameInterface.updateLives(this.lives);


        if (this.lives <= 0) GameOver();
        else { Respawn(); }
    }

    private void Update() {
        // update timer
        if (winCondition == WinCondition.Time) {
            timeRemaining -= Time.deltaTime;

            int minutesRemaining = (int) timeRemaining / 60;
            int newSecondsRemaining = (int) timeRemaining % 60;

            if (newSecondsRemaining != secondsRemaining) {
                secondsRemaining = newSecondsRemaining;
                string newText = minutesRemaining + ":" + secondsRemaining.ToString("D2");
                inGameInterface.updateWinProgress(newText);
            }

            if (timeRemaining <= 0f) {
                GameOver();
            } else if (timeRemaining <= 20f && !signalledPlanet) {
                signalledPlanet = true;
                planet.setSidescroll(1);
            }
        }
    }

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
        fadescreen.fadeOut();
        lives = 0;
        score = 0;
        inGameInterface.updateLives(lives);
        inGameInterface.updateScore(score);
        player.gameObject.SetActive(false);
        Invoke(nameof(ExitToMainMenu), gameEndTime);
    }
}
