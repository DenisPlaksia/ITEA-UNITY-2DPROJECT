using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

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
