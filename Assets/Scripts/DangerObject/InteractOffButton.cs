using UnityEngine;

public class InteractOffButton : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject _dangerObjectOff;

    public void Interact()
    {
        Destroy(_dangerObjectOff);
        Destroy(this);
    }
}
