using UnityEngine;

public class menuBehaviour : MonoBehaviour {
    public void LoadNextScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
