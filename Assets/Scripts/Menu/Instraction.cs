using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class Instraction : MonoBehaviour
{

    private TextMeshProUGUI _instractionText;

    private List<string> _arrayString = new List<string>()
    {
        "Hello!",
        "Welcome to draw hell",
        "For moving press A & D \t Press  Enter for shooting",
        "Press W for moving on ladder",
        "Collect stars on the level if you want of course\t (P.S its not important)",
        "Dont collision with enemy or other denger object, you can die",
        "Good luck, (You can set name in setting) :)" 
    };
    private void Start()
    {
        _instractionText = GetComponent<TextMeshProUGUI>();
        StartCoroutine("SwichText");
    }

    private IEnumerator SwichText()
    {
        for (int i = 0; i < _arrayString.Count; i++)
        {
            _instractionText.text = _arrayString[i];
            yield return new WaitForSeconds(2.5f);
        }
    }
}
