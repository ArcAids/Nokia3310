using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text gameText;
    [SerializeField] Animator UIAnimator;
    PlayerManager players;

    public static GameManager Instance;

    Coroutine saying;
    private void Awake()
    {
        gameText.text = "";
        Instance = this;
        players = GetComponent<PlayerManager>();
        
    }

    private void Start()
    {
        GetComponent<PlayerManager>().StartGame();
    }

    public void OnWin()
    {
        UIAnimator.SetTrigger("Dead");
        players.DisableControls();
    }

    public void GameOver()
    {
        Say("Game Over!!");
        players.DisableControls();
        ReloadSceneSoon();
    }

    public void Say(string dialogue)
    {
        if (dialogue.Length == 0)
            return;
        if(saying!=null)
            StopCoroutine(saying);
        saying=StartCoroutine(SayDialogue(dialogue));
    }

    IEnumerator SayDialogue(string dialogue)
    {
        
        gameText.text = "";
        foreach (var letter in dialogue)
        {
            gameText.text += letter;
            yield return new WaitForSeconds(1f/dialogue.Length);
        }
        yield return new WaitForSeconds(1);
        gameText.text = "";
        

    }

    public void ReloadSceneSoon()
    {
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
