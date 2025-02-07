using UnityEngine;
using System.Collections;

public class SafeRoomMusic : MonoBehaviour
{
    public AudioSource safeRoomMusic; // Assign the AudioSource in the Inspector
    public float fadeDuration = 1.5f; // Time in seconds for fade in/out
    private Coroutine fadeCoroutine; // Track current fade coroutine
    private bool isInside = false; // Track if the player is inside

    void Start()
    {
        if (safeRoomMusic == null)
            safeRoomMusic = GetComponent<AudioSource>(); // Auto-assign if attached

        safeRoomMusic.volume = 0f; // Start muted
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInside)
        {
            isInside = true;
            if (fadeCoroutine != null) StopCoroutine(fadeCoroutine); // Stop any active fade-out
            fadeCoroutine = StartCoroutine(FadeInMusic());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInside)
        {
            isInside = false;
            if (fadeCoroutine != null) StopCoroutine(fadeCoroutine); // Stop any active fade-in
            fadeCoroutine = StartCoroutine(FadeOutMusic());
        }
    }

    IEnumerator FadeInMusic()
    {
        if (!safeRoomMusic.isPlaying)
            safeRoomMusic.Play(); // Ensure the music starts

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            safeRoomMusic.volume = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        safeRoomMusic.volume = 0.5f;
    }

    IEnumerator FadeOutMusic()
    {
        float startVolume = safeRoomMusic.volume;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            safeRoomMusic.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        safeRoomMusic.volume = 0f;
        safeRoomMusic.Stop(); // Fully stop music after fading out
    }
}
