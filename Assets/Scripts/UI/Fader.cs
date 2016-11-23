using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {
    public Color initialColor;

    private Image image;

    private Color destColor;
    private float destSpeed;
    private OnFaded onFaded;
    private bool isFading = false;

    public delegate void OnFaded();

	void Awake ()
    {
        image = GetComponent<Image> ();
        image.color = initialColor;
	}

    public void Fade(Color _destColor, float _destSpeed, OnFaded callback)
    {
        onFaded = callback;
        destColor = _destColor;
        destSpeed = _destSpeed;
        isFading = true;
    }
	
	void Update ()
    {
        if (isFading && destColor != image.color) {
            image.color = Color.Lerp (image.color, destColor, Time.deltaTime * destSpeed);
        }

        if (isFading && Mathf.Abs(image.color.a - destColor.a) < 0.05f) {
            onFaded ();
            isFading = false;
        }
	}
}
