using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy_Action : MonoBehaviour
{
    public Tilemap tilemap;
    public int numberType;  //0静止 1向上 2向下 3向左 4向右
    public float waitTime = 2.0f;
    Animator animator;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        Vector3Int cell = tilemap.WorldToCell(position);
        Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
        cellCenter.y -= 1.25f;
        transform.position = cellCenter;
        animator = this.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            numberType = Random.Range(0, 5);
            Action(numberType);
            waitTime = Random.Range(5, 11) * 0.2f;
        }
        
    }

    void Action(int Type)
    {
        if (Type == 0)
        {
            animator.SetBool("isUp", false);
            animator.SetBool("isDown", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
        }
        else if (Type == 1)
        {
            animator.SetBool("isUp", true);
            Vector3 temp = transform.position;
            temp.y += 2;
            transform.position = temp;
            StartCoroutine(ActionReturns("isUp"));
        }
        else if (Type == 2)
        {
            animator.SetBool("isDown", true);
            Vector3 temp = transform.position;
            temp.y -= 2;
            transform.position = temp;
            StartCoroutine(ActionReturns("isDown"));
        }
        else if(Type == 3)
        {
            animator.SetBool("isLeft", true);
            Vector3 temp = transform.position;
            temp.x -= 2;
            transform.position = temp;
            StartCoroutine(ActionReturns("isLeft"));
        }
        else if (Type == 4)
        {
            animator.SetBool("isRight", true);
            Vector3 temp = transform.position;
            temp.x += 2;
            transform.position = temp;
            StartCoroutine(ActionReturns("isRight"));
        }
    }

    IEnumerator ActionReturns(string returnName)
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool(returnName, false);
    }
}
