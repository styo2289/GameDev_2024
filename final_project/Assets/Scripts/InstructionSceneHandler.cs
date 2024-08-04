using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionSceneHandler : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void LoadGame(){
        SceneManager.LoadScene(sceneName);
    }
}
