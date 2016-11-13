using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour {

    private float RELOAD_TIME = 1.7f;
    List<string> iList = new List<string>();
    
    int indexCredit;
    // Use this for initialization
    void Start () {
        indexCredit = 0;
        
        iList.Add("Credits : Antoine F.- Music & Sound Design");
        iList.Add("Credits : Bemba D.- Code");
        iList.Add("Credits : Corentin F.- M. - 2D/3D Graphics");
        iList.Add("Credits : Gabriel P.- Code");
        iList.Add("Credits : Kevin S.- Game Design & 3D Graphics");
        iList.Add("Credits : Yendhi W.- Code");
        Reload();
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void Reload()
    {
        if (indexCredit <= 5)
        {
        GetComponent<Text>().text = iList[indexCredit];
        indexCredit++;
        }
        else
        {
            indexCredit = 0;
        }
        Invoke("Reload", 1.9f);
    }
}
