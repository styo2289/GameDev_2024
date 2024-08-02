using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [ColorUsage(true,true)]
    private Color flashColor = Color.white;
    private Material materials;
    private float flashTime = 0.15f, flashAmount = 0f, elapseTime = 0f;
    private SpriteRenderer spriteRenderer;

    private Coroutine startFlashRoutine;

    public void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        materials = spriteRenderer.material;
    }

    public void CallFlashRoutine(){
        startFlashRoutine = StartCoroutine(FlashPeriod());
    }

    private IEnumerator FlashPeriod(){
        materials.SetColor("_FlashColor", flashColor);

        while(elapseTime < flashTime){
            elapseTime += Time.deltaTime;

            flashAmount = Mathf.Lerp(1f, 0f, (elapseTime / flashTime));
            materials.SetFloat("_FlashAmount", flashAmount);

            yield return null;
        }        
    }
}
