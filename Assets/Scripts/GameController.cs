using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _menuPlane;



    private void Start()
    {
        _menuPlane.SetActive(false);
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _menuPlane.SetActive(true);
        }
    }
}
