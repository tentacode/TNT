using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour {    
    List<string> iList = new List<string>();
    
    int indexCredit;
    // Use this for initialization
    void Start () {
        indexCredit = 0;
        
        iList.Add("Credits - Antoine - Music and Sound Design");
        iList.Add("Credits - Bemba - Code");
        iList.Add("Credits - Corentin - Graphics");
        iList.Add("Credits - Gabriel - Code");
        iList.Add("Credits - Kevin - Game Design and Graphics");
        iList.Add("Credits - Yendhi - Code");
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
