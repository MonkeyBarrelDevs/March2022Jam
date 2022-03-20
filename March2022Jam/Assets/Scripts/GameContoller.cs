using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    [SerializeField] bool transitionByMusic;
    [SerializeField] float musicLength;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] LevelLoader loader;
    [SerializeField] float respawnDelay = .5f;
    [SerializeField] float invulerabilityTime = .3f;
    [SerializeField] PlayerMovement player;
    [SerializeField] BossController boss;
    [SerializeField] int HP = 3;
    private float iFrameTime = -.01f;

    public void SetHP(int number)
    {
        HP = number;
    }

    public void SubtractHP(int number)
    {
        if (iFrameTime <= 0)
        {
            Debug.Log("Ouch");
            HP -= number;
            iFrameTime = invulerabilityTime;
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        SetMouseState(true);
        Time.timeScale = 0f;
    }

    public void Unpause()
    {   
        pauseMenu.SetActive(false);
        SetMouseState(false);
        Time.timeScale = 1f;
    }

    public void Lose()
    {
        player.Die();
        loader.DelayLoadLevelWithName(loader.getSceneName(), respawnDelay);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Replace 0 and "Temp" with the length of the first song and the scene name.
        loader = FindObjectOfType<LevelLoader>();
        if(transitionByMusic)
            StartCoroutine(StaggerAfterSong(musicLength));
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
            Lose();

        if (iFrameTime > 0)
            iFrameTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    public void SetMouseState(bool state) 
    {
        if (state)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void GoToNextPhase() 
    {
        loader.LoadNextLevel();
    }

    IEnumerator StaggerAfterSong(float delay)
    {
        yield return new WaitForSeconds(delay);
        boss.Stagger();
    }
}
