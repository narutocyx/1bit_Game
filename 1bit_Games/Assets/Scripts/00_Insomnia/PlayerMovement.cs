using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float moveH, moveV;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //moveH = Input.GetAxis("Horizontal") * moveSpeed;
        //moveV = Input.GetAxis("Vertical") * moveSpeed;
        //rb.velocity = new Vector2(moveH, moveV);

        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SleepingEnergy"))
        {
            Destroy(other.gameObject);
            GameManager.instance.LevelUp();
            //UIManager.instance.UpdateUI();
        }
    }
}
