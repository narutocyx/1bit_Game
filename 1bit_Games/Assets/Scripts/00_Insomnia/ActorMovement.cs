using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMovement : MonoBehaviour
{
    private float rotateSpeed;
    private float moveSpeed;

    private void Start()
    {
        rotateSpeed = GameManager.instance.actorRotateSpeed;
        moveSpeed = GameManager.instance.actorMoveSpeed;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(2, 2, 0));
        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Center"))
        {
            Destroy(gameObject);
            GameManager.instance.LevelDown();
            //UIManager.instance.UpdateUI();
        }
    }
}
