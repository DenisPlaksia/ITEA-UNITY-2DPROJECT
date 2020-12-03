using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalWin : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _winPanel;
    public void Interact()
    {
        if (Player.Singleton._score > 5)
        {
            PlayerController._canMove = false;
            _winPanel.SetActive(true);
        }
    }
}
