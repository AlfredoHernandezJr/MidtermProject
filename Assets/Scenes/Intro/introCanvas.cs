using System.Collections;
using UnityEngine;
using static UnityEngine.UI.Image;

public class IntroCanvas : MonoBehaviour
{
    public GameObject introText;
    public GameObject titleText;
    public float introDuration = 15f;
    public float titleDuration = 1f;
    public Vector3 titleScale = new Vector3(1.5f, 1.5f, 1f);
    public int buttonWidth;
    public int buttonHeight;
    private int origin_x;
    private int origin_y;
    private bool showGUI = false;

    private void Start()
    {
        buttonWidth = 200;
        buttonHeight = 50;
        origin_x = Screen.width / 2 - buttonWidth / 2;
        origin_y = Screen.height / 2 - buttonHeight * 2;
        origin_y += 150;
    }

    private void Update()
    {
        // Calculate the current time elapsed as a percentage of the total time
        float introTimeElapsed = Time.time;
        float introT = Mathf.Clamp01(introTimeElapsed / introDuration);

        // Interpolate between the starting and ending positions using the current time percentage
        float y = Mathf.Lerp(-320f, 1225f, introT);

        // Set the position of the introText game object to the interpolated position
        introText.transform.localPosition = new Vector3(0f, y, 0f);

        if (introT >= 1f)
        {
            // Activate the titleText object
            titleText.SetActive(true);

            // Start the scale-in animation
            StartCoroutine(ScaleIn(titleText, titleDuration, titleScale));
        }
    }

    private void OnGUI()
    {
        if (showGUI)
        {
            if (GUI.Button(new Rect(origin_x, origin_y, buttonWidth, buttonHeight), "Start Game!"))
            {
                Application.LoadLevel(1);
            }
        }
    }

    private IEnumerator ScaleIn(GameObject obj, float duration, Vector3 targetScale)
    {
        // Gradually increase the object's scale over the specified duration
        Vector3 startScale = obj.transform.localScale;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            obj.transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the object's scale to the target scale
        obj.transform.localScale = targetScale;

        // Set the showGUI flag to true to display the GUI
        showGUI = true;
    }
}