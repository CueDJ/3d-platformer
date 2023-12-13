
using System.Collections;
using TMPro;
using UnityEngine;

public class Fps : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fpsText;
    private float count;

    private IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Update()
    {
        fpsText.text = "FPS: " + Mathf.Round(count);
    }
}