using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject actor;

    public float actorRotateSpeed;
    public float actorMoveSpeed;
    public float bornTimer;
    public int level;
    public bool isGameStart;
    public bool isGameEnd;
    public Transform ImageUI;

    private float timer;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        timer = bornTimer;
        level = 1;
        Cursor.visible = false;

    }

    private void Update()
    {
        if (isGameStart)
        {
            StartGame();
            ChangeSleepState();
            EndGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void CreatePickedActors()
    {
        float bornPosX = 0;
        float bornPosY = 0;
        int dir = Random.Range(0, 3);

        switch (dir)
        {
            //up
            case 0:
                bornPosX = Random.Range(-20f, 20f);
                bornPosY = Random.Range(9f, 14f);
                break;
            //down
            case 1:
                bornPosX = Random.Range(-20f, 20f);
                bornPosY = Random.Range(-14f, -9f);
                break;
            //left
            case 2:
                bornPosX = Random.Range(-20f, -15f);
                bornPosY = Random.Range(-14f, 14f);
                break;
            //right
            case 3:
                bornPosX = Random.Range(15f, 20f);
                bornPosY = Random.Range(-14f, 14f);
                break;
        };

        Instantiate(actor, new Vector2(bornPosX, bornPosY), Quaternion.identity);
    }

    public void LevelUp()
    {
        level++;
        //UIManager.instance.UpdateUI();
        //actorMoveSpeed += 1;
        //actorRotateSpeed += 2;
        if (bornTimer > 0.3f)
            bornTimer -= 0.2f;
    }

    public void LevelDown()
    {
        level -= 2;
        //UIManager.instance.UpdateUI();
        //if (bornTimer < 1.8f) 
        //    bornTimer += 0.2f;
    }

    void ChangeSleepState()
    {
        if (level >= 4 && level < 9)
        {
            UIManager.instance.SetSleepStatUI(1);
        }
        else if (level >= 9 && level < 19)
        {
            UIManager.instance.SetSleepStatUI(2);
        }
        else if (level >= 19 && level < 39)
        {
            UIManager.instance.SetSleepStatUI(3);
        }
    }

    void StartGame()
    {
        if (timer <= 0)
        {
            CreatePickedActors();
            timer = bornTimer;
        }
        timer -= Time.deltaTime;
    }

    void EndGame()
    {
        if (level >= 50)
        {
            isGameStart = false;
            isGameEnd = true;
            ImageUI.gameObject.SetActive(true);
        }
    }
}
