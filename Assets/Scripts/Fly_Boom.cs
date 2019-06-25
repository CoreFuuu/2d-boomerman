using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Boom : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originPos;
    public int type;
    void Start()
    {
        originPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Fly(type);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall2") || other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Bomb"))
        {
            Boom boom = other.GetComponent<Boom>();
            boom.boomDirectly = true;
        }
    }

    void Fly(int type)
    {
        if (type == 0)  //向上
        {
            if (transform.position.y - originPos.y <= 4.0f)
            {
                transform.Translate(Vector3.up * 20 * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (type == 1)  //向下
        {
            if (originPos.y - transform.position.y <= 4.0f)
            {
                transform.Translate(Vector3.down * 20 * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (type == 2)  //向右
        {
            if (transform.position.x - originPos.x <= 4.0f)
            {
                transform.Translate(Vector3.right * 20 * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (type == 3)  //向左
        {
            if (originPos.x - transform.position.x <= 4.0f)
            {
                transform.Translate(Vector3.left * 20 * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
