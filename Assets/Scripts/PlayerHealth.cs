using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] InGameMenu inGameMenu;
    [SerializeField] int lives;

    public void Crash()
    {
        inGameMenu.EndGame();
        gameObject.SetActive(false);
    }

}
