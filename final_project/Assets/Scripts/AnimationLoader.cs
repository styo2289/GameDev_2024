using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLoader : MonoBehaviour
{
    [SerializeField] Animator animatedImage;
    // Start is called before the first frame update
    void Start()
    {
        animatedImage.Play("start2");
    }
    
}
