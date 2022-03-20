using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] float invulerabilityTime = .3f;
    private float iFrameTime = 0f;
    private int HP = 1;
    
    public void SetHP(int number)
    {
        HP = number;
    }

    public void SubtractHP(int number)
    {
        if (iFrameTime <= 0)
        {
            HP = HP - number;
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

    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public void Lose()
    {
        Pause();
        //Transition to death screen (SceneManager method)
    }

    // Start is called before the first frame update
    void Start()
    {
        //Replace 0 and "Temp" with the length of the first song and the scene name.
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
            Lose();

        if (iFrameTime >= 0)
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
}
