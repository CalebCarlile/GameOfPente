using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour {

    public TextMesh notification;

    public void Notify(Vector2 origin, string text, int fontSize, float duration, Vector3 movement, Color startColor)
    {
        notification.transform.position = new Vector3(origin.x, origin.y, -2);
        notification.fontSize = fontSize;
        notification.text = text;
        notification.color = startColor;
        StartCoroutine(Fade(duration, movement, startColor));
    }

    public IEnumerator Fade(float duration, Vector3 movement, Color startColor)
    {
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            notification.transform.position += movement * Time.deltaTime/duration;
            notification.color = Color.Lerp(startColor, new Color(1, 1, 1, 0), t/duration);
            yield return null;
        }
    }
}
