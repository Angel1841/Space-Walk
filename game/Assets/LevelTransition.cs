using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision != null)
        {
            if (collision.tag.Equals("Player"))
            {
                StartCoroutine(LoadDelay());
            }
        }
    }


    private IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(2f);
        TransitionNextLevel();
    }

    private void TransitionNextLevel()
    {
        SceneManager.LoadScene("Levels Screen");
    }
}
