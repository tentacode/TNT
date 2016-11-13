using UnityEngine;
using System.Collections;

public class ValidationController : MonoBehaviour {

    public GameObject image1,image2,image3,image4,text1;
    int countPlayer;
    bool img1, img2, img3, img4, start;
	// Use this for initialization
	void Start () {
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
        text1.SetActive(false);
        countPlayer = 0;
        img1 = false;
        img2 = false;
        img3 = false;
        img4 = false;
        start = false;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Shoot1"))
        {
            image1.SetActive(true);
            if (img1==false)
            {
                countPlayer += 1;
                img1 = true;
            }
            Debug.Log(countPlayer);
        }
        if (Input.GetButtonDown("Shoot2"))
        {
            image2.SetActive(true);
            if (img2 == false)
            {
                countPlayer += 1;
                img2 = true;
            }
            Debug.Log(countPlayer);
        }
        if (Input.GetButtonDown("Shoot3"))
        {
            image3.SetActive(true);
            if (img3 == false)
            {
                countPlayer += 1;
                img3= true;
            }
        }
        if (Input.GetButtonDown("Shoot4"))
        {
            image4.SetActive(true);
            if (img4 == false)
            {
                countPlayer += 1;
                img4 = true;
            }
        }

        if (countPlayer>=2)
        {
            text1.SetActive(true);
            if (start == false)
            {
                start = true;
            }
        }
        if (start == true)
        {
            if (Input.GetButtonDown("Submit"))
            {

            }
        }

    }
}
