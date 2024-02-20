using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from: https://johnleonardfrench.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/#:~:text=There's%20no%20separate%20function%20for,script%20will%20do%20the%20rest.
//To fade out: StartCoroutine(FadeAudio.StartFade(GameObject.Find("Background Music").GetComponent<AudioSource>(), 0.5f, 0f, 0.5f));
//To fade in: StartCoroutine(FadeAudio.StartFade(GameObject.Find("Background Music").GetComponent<AudioSource>(), 0.5f, 0.5f, 0f));

public static class FadeAudio{
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume, float initVol) {
        float currentTime = 0;
        audioSource.volume = initVol; 
        float start = audioSource.volume;
        while (currentTime < duration) {
            
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
