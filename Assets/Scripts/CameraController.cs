using UnityEngine;

public class CameraController : MonoBehaviour
{

    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var playerPOS = player.transform.position;
        var cameraPOS = transform.position;

        cameraPOS.x = playerPOS.x;
        //cameraPOS.y = playerPOS.y;

        transform.position = cameraPOS;
    }
}
