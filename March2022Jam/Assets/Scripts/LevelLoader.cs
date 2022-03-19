using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = .5f;

    private void Start()
    {
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

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadNextLevel();
    }
}
