using UnityEngine;
using UnityEngine.SceneManagement;

public class UILibrary : MonoBehaviour {

    /// <summary>
    /// Load a specific scene in single mode
    /// </summary>
    /// <param name="p_scene">Number of the scene</param>
	public void LoadSingleScene(int p_scene)
    {
        SceneManager.LoadScene(p_scene, LoadSceneMode.Single);
    }
}
