using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] Animator animatedImage;
    public void PlayGame(){
        GetComponent<AudioSource>().Play();
        StartCoroutine(LoadScene());
    }

    public void QuitGame(){
        Application.Quit();
    }

    private IEnumerator LoadScene(){
        animatedImage.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameScene");
    }
}
