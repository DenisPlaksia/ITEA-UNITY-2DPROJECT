using UnityEngine;

public class PortalWin : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _winPanel;
    public void Interact()
    {
        PlayerController._canMove = false;
        _winPanel.SetActive(true);
    }
}
