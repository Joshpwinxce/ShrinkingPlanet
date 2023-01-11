using UnityEngine;
using TMPro;

public class FpsDisplay : MonoBehaviour
{
    public TextMeshProUGUI FpsText;

    private float pollingTime = 1f;
    private float time;
    private int frameCount;


    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FpsText.text = frameRate.ToString() + " Fps";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
