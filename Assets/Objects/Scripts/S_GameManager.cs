using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameManager : MonoBehaviour
{
    public Scene sceneToLoad;   
    public float deathCooldown;
    GameObject player;

    private void Start()
    {
     
    }
    private void Update()
    {
        if (GameObject.Find("PlayerShip") == null)
        {
            Invoke("GameOver", deathCooldown);
        }
        
    }
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
