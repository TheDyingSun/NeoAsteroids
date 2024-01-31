using UnityEngine;
using UnityEngine.Audio;

// adapted from Sasquatch B Studios: https://www.youtube.com/watch?v=DU7cgVsU2rM
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource sourceObject;

    private void Awake() {
        if (instance == null) { instance = this; }
    }

    public void PlayClip(AudioClip clip, Transform spawnTransform, float volume) {
        AudioSource source = Instantiate(sourceObject, spawnTransform.position, Quaternion.identity);

        source.clip = clip;
        source.volume = volume;
        source.Play();

        float clipLength = source.clip.length;
        Destroy(source.gameObject, clipLength);
    }
}
