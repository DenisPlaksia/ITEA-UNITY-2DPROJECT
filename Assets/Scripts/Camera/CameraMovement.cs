using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.Singleton.transform.position.x, 0f, transform.position.z);
    }
}
