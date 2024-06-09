using UnityEngine;
using UnityEngine.SceneManagement; 
public class MenuInciall : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}