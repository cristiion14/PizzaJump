using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling; 

public class DissolveShader : MonoBehaviour
{
   public  Material dissolve;

   public bool isDissolving = false;
    float fade = 1;

    void Start()
    {
      //  dissolve = GetComponent<Material>();
    }

    void Update()
    {

       
        if(isDissolving)
        {
            fade -= Time.deltaTime;

            if(fade<=0f)
            {
                fade = 1f;
                isDissolving = false;
            }
                dissolve.SetFloat("_Fade", fade);
        }
    }
}
