using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= 0)
        {
            transform.position = transform.position;
        }
        transform.position = new Vector3(Player.Singleton.transform.position.x, 0f, transform.position.z);
    }
}
