using UnityEngine;

public class PortalWin : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _winPanel;
    public void Interact() => Player.Singleton.WinGame();
}
