using UnityEngine;

public class MenuController : MonoBehaviour
{
    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
