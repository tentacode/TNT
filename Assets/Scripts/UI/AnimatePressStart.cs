using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimatePressStart : MonoBehaviour
{
    private RectTransform rect;
    public float amplitude = 20.0f;
    public float speed = 1.0f;
    private int direction = 1;
    private Vector2 destination;

	void Start ()
    {
        SetDestination ();
        rect = GetComponent<RectTransform> ();
	}
	
	void Update ()
    {
        rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, destination, Time.deltaTime * speed);

        if (Mathf.Abs(rect.anchoredPosition.y - destination.y) <= 0.1f) {
            direction = -direction;
            SetDestination ();
        }
	}

    void SetDestination()
    {
        destination = new Vector2 (0, amplitude * direction);
    }
}
