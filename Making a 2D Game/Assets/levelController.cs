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
        foreach(Enemy enemy in enemies)
        {
            if (enemy != null)
                return;
        }

        Debug.Log("Killed all enemies");
        
        nextLevelIndex++;
        string nextLevelName = "Level" + nextLevelIndex;

        SceneManager.LoadScene(nextLevelName);
    }
}
