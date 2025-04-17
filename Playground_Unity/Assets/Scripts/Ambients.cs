using UnityEngine;

public class Ambients : MonoBehaviour, IActions, IToggleable
{
    public Material mat;
    public float intensity = 6f;
  
    public void ActiveFunctionsByAction(string actionName, string hexColor)
    {
        switch(actionName)
        {
            case"set_color":

                if (ColorUtility.TryParseHtmlString(hexColor, out Color emissionColor))
                {
                    mat.SetColor("_EmissionColor", emissionColor * intensity);                 
                }
                else
                {
                    Debug.LogError("color Hex is wrong! ");
                }
                break;
        }      
    }
    public void ActiveFunction(bool isActive)
    {
        if(isActive)
        { 
            mat.EnableKeyword("_EMISSION");
        }
        else
        {
            mat.DisableKeyword("_EMISSION");
        }
       
    }
}
