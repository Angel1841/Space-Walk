using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int kiwis = 0;
    [SerializeField] private TextMeshProUGUI kiwisText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("kiwi"))
        { 
            Destroy(collision.gameObject);
            kiwis++;
            kiwisText.text = "Kiwis: " +kiwis;
            PlayerPrefs.SetInt("Kiwis", kiwis);
        }
    
    }
}
