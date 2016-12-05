using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private Text text;
    private string shootText = "SHOOT !";

	void Start ()
    {
        text = GetComponent<Text> ();
        text.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
        Invoke ("Decrement", 1);    
	}

    void Decrement()
    {
        if (text.text == shootText) {
            text.enabled = false;
            return;
        }

        int number = System.Int32.Parse(text.text) - 1;
        if (number == 0) {
            text.text = shootText;
            text.transform.localScale = new Vector3 (0.4f, 0.4f, 0.4f);
            Invoke ("Decrement", 0.7f);    
        } else {
            text.text = number.ToString ();
            text.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
            Invoke ("Decrement", 1);
        }

    }

    void Update ()
    {
        text.transform.localScale = Vector3.Lerp(text.transform.localScale, new Vector3(1, 1, 1), 0.3f);
	}
}
