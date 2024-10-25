using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    // void Awake() {
    //     LoadNextScene();
    // }
    void Update()
    {
        Debug.Log("scene loader script");
        if (Input.GetMouseButtonDown(0))
        LoadNextScene();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player enter portal");
        if (other.CompareTag("Player"))
        {
            LoadNextScene();
        }
    }
    void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int nextLevelBuildIndex = 1 - scene.buildIndex;
        SceneManager.LoadScene(nextLevelBuildIndex);
    }

}