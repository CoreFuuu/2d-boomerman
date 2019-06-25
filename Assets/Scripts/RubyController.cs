using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;
    int currentHealth;
    public int health { get { return currentHealth; } }

    public Tilemap tilemap;
    public GameObject bombPrefab;

    Rigidbody2D rigidbody2D;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth / 2;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Vector3 position = rigidbody2D.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y+1);
            //Vector3Int cell = tilemap.WorldToCell(position);
            //Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
            Instantiate(bombPrefab, position, Quaternion.identity);
        }
        //canMove = true;
    }



    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    public void move()
    {
        Vector3 position = rigidbody2D.position;
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isRunUp", true);
            position.y += 2;
            rigidbody2D.MovePosition(position);
            //position.y += 2;
            //Vector3Int cell = tilemap.WorldToCell(position);
            //Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
            //cellCenter.y -= 1.0f;
            //rigidbody2D.MovePosition(cellCenter);
            StartCoroutine(SetRunBack("isRunUp"));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("isRunDown", true);
            position.y -= 2;
            rigidbody2D.MovePosition(position);
            //position.y -= 2;
            //Vector3Int cell = tilemap.WorldToCell(position);
            //Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
            //cellCenter.y -= 1.0f;
            //rigidbody2D.MovePosition(cellCenter);
            StartCoroutine(SetRunBack("isRunDown"));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isRunLeft", true);
            position.x -= 2;
            rigidbody2D.MovePosition(position);
            //position.x -= 2;
            //Vector3Int cell = tilemap.WorldToCell(position);
            //Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
            //cellCenter.y -= 1.0f;
            //rigidbody2D.MovePosition(cellCenter);
            StartCoroutine(SetRunBack("isRunLeft"));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("isRunRight", true);
            position.x += 2;
            rigidbody2D.MovePosition(position);
            //position.x += 2;
            //Vector3Int cell = tilemap.WorldToCell(position);
            //Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
            //cellCenter.y -= 1.0f;
            //rigidbody2D.MovePosition(cellCenter);
            StartCoroutine(SetRunBack("isRunRight"));
        }
    }
    IEnumerator SetRunBack(string name)
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool(name, false);
    }
}