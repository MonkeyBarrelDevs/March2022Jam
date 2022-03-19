using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = .5f;
    [SerializeField] bool autoTransition = true;
    [SerializeField] float autoTransDelay = 0f;
    [SerializeField] string autoTransTargetScene = "SampleScene";

    private void Start()
    {
        if (autoTransition) 
        {
            StartCoroutine(Delay(autoTransTargetScene, autoTransDelay));
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReplayTransition()
    {
        StartCoroutine(CycleTransition());
    }

    public void LoadLevelAtIndex(int index)
    {
        StartCoroutine(LoadLevel(index));
    }

    public void LoadLevelWithName(string name)
    {
        StartCoroutine(LoadLevel(name));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(string name)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(name);
    }

    IEnumerator CycleTransition()
    {
        yield return new WaitForSeconds(transitionTime);

    }

    IEnumerator Delay(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadLevelWithName(name);
    }
}
