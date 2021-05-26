using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTarget : MonoBehaviour
{
    public GameObject gun;

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.gameManager.inventory.Contains(gun))
        {
            GameManager.gameManager.inventory.Remove(gun);
        }
        GetComponent<FadeOut>().fade_out = true;
    }
}
