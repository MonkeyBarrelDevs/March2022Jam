using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    private int HP;
    
    public void SetHP(int number)
    {
        HP = number;
    }

    public void SubtractHP(int number)
    {
        HP = HP - number;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
    }

    public void TransitionAfter(int seconds, string sceneName)
    {
        StartCoroutine(Wait(seconds));
        //Transition to next scene using SceneManager and sceneName
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
        TransitionAfter(0, "Temp");
    }

    // Update is called once per frame
    void Update()
    {
        if(HP == 0)
            Lose();
    }
}
