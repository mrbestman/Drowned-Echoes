using UnityEngine;
using TMPro;

public class FlashlightHint : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    private bool isShowing = false;

    void Start()
    {
        hintText.alpha = 0; // Start hidden
    }

    public void ShowHint()
    {
        if (!isShowing)
        {
            isShowing = true;
            hintText.text = "F to turn on the flashlight";
            StartCoroutine(FadeHint());
        }
    }

    private System.Collections.IEnumerator FadeHint()
    {
        hintText.alpha = 1; // Show text
        yield return new WaitForSeconds(3f); // Wait 3 seconds
        for (float t = 1; t > 0; t -= Time.deltaTime)
        {
            hintText.alpha = t; // Fade out
            yield return null;
        }
        hintText.alpha = 0;
        isShowing = false;
    }
}
