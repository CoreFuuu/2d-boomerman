using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Boom : MonoBehaviour
{
    public float explodeTime = 2.0f;
    Animator animator;
    AudioSource audioSoure;
    public GameObject flyUp;
    public GameObject flyDown;
    public GameObject flyLeft;
    public GameObject flyRight;
    bool isTrigger = true;
    public bool boomDirectly = false;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
        audioSoure = this.gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        explodeTime -= Time.deltaTime;
        if (explodeTime <= 0f || boomDirectly == true)
        {
            Debug.Log("BOOM!!!!!!!");
            if (isTrigger)
            {
                flyFourDirection();
                audioSoure.Play();
            }
            isTrigger = false;
            animator.SetBool("BOOM", true);
            StartCoroutine(BoomFinish());
            boomDirectly = false;
            //Destroy(this.gameObject);
        }
    }

    void flyFourDirection()
    {
        Instantiate(flyUp, this.transform.position, Quaternion.identity);
        Instantiate(flyDown, this.transform.position, Quaternion.identity);
        Instantiate(flyLeft, this.transform.position, Quaternion.identity);
        Instantiate(flyRight, this.transform.position, Quaternion.identity);

    }

    IEnumerator BoomFinish()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
