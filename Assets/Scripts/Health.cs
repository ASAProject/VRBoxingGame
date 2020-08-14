using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Image healthbar,enemyhealthbar;
    [SerializeField]
    public static float fillamount = 10f,enemyhealth = 10f;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GameObject.Find("healthbar").GetComponent<Image>();
        enemyhealthbar = GameObject.Find("EnemyHealth").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (fillamount)/10f;
        if(healthbar.fillAmount == 0){
            PlayerPrefs.SetString("win", "You lost");
            SceneManager.LoadScene("Retry");
            
        }
        enemyhealthbar.fillAmount = enemyhealth/10f;
        if (enemyhealthbar.fillAmount == 0)
        {
            PlayerPrefs.SetString("win", "You Win");
            SceneManager.LoadScene("Retry");
            
        }
    }
}
