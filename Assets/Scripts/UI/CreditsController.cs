using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour {    
    List<string> iList = new List<string>();
    int indexCredit;

    void Start ()
    {
        indexCredit = 0;
        
        iList.Add("Credits - Antoine - Music and Sound Design");
        iList.Add("Credits - Bemba - Code");
        iList.Add("Credits - Corentin - Graphics");
        iList.Add("Credits - Gabriel - Code");
        iList.Add("Credits - Kevin - Game Design and Graphics");
        iList.Add("Credits - Yendhi - Code");

        Reload();
    }

    void Reload()
    {
        if (indexCredit > iList.Count - 1) {
            indexCredit = 0;
        }

        GetComponent<Text>().text = iList[indexCredit];
        indexCredit++;

        Invoke("Reload", 2.0f);
    }
}
