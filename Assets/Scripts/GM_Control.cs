using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GM_Control : MonoBehaviour
{
    public GameObject UI_Lose;
    public GameObject UI_Win;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        UI_Lose.SetActive(false);
        UI_Win.SetActive(false);
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (GameObject.FindWithTag("Player")==null)
        {
            UI_Lose.SetActive(true);
            audioSource.Stop();
        }

        if (GameObject.FindWithTag("wall2") == null)
        {
            UI_Win.SetActive(true);
        }
    }
}
