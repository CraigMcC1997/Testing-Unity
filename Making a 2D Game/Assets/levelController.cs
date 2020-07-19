using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    private Enemy[] enemies;
    private static int nextLevelIndex = 1;

    private void OnEnable()
    {
        enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reloading Game");

            string currentLevelName = "Level" + nextLevelIndex;
            SceneManager.LoadScene(currentLevelName);
        }

        Debug.Log("Killed all enemies");

        foreach (Enemy enemy in enemies)
        {
            if (enemy != null)
                return;
        }

        
        
        nextLevelIndex++;
        string nextLevelName = "Level" + nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
