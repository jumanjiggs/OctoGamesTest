using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Services
{
    public class GameControl : MonoBehaviour
    {
        public void Respawn() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void LeaveGame() => 
            Application.Quit();
    }
}