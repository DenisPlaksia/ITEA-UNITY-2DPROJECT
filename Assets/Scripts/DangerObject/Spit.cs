using UnityEngine;

public class Spit : MonoBehaviour
{
    [SerializeField] private float _speedRotate;
    private void Update()
    {
        Rotate(_speedRotate);
    }
    private void Rotate(float speed)
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
