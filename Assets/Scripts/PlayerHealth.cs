using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] InGameMenu inGameMenu;
    [SerializeField] GameObject destroyNova;
    [SerializeField] int lives;

    void Start()
    {
        
    }

    public void Crash()
    {
        SoundManager audioManager = FindObjectOfType<SoundManager>();
        audioManager.GetComponent<AudioSource>().PlayOneShot(audioManager.GetComponent<SoundManager>().crash);              

        inGameMenu.EndGame();
        gameObject.SetActive(false);
    }
    
}
