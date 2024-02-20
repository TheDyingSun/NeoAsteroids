using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    void Start() {
        StartCoroutine(FadeAudio.StartFade(GameObject.Find("Background Music").GetComponent<AudioSource>(), 0.5f, 0.5f, 0f));
    }
}
