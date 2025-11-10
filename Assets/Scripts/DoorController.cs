using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            var playerScript = collision.gameObject.GetComponent<PlayerController>();
            if(playerScript.GetScore() == 5){
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
        }
    }
}
