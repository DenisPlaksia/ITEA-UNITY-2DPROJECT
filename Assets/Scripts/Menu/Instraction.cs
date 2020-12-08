using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class Instraction : MonoBehaviour
{

    private TextMeshProUGUI _instractionText;
    private string[] _arrayString =
    {
        "Press A & D for side moving\tPress  Enter for shooting",
        "Collect stars on the level",
        "Dont collision with enemy or other denger object",
        "Good luck :)",
    };
    private void Start()
    {
        _instractionText = GetComponent<TextMeshProUGUI>();
        StartCoroutine("SwichText");
    }

    private IEnumerator SwichText()
    {
        for (int i = 0; i < _arrayString.Length; i++)
        {
            _instractionText.text = _arrayString[i];
            yield return new WaitForSeconds(3f);
        }
    }
}
