using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int lives;

    public void Crash()
    {
        gameObject.SetActive(false);
    }

}
