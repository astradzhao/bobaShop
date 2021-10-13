using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempDisplayManager : MonoBehaviour
{
    #region Public Variables
    public Text teaBaseTxt;
    public Text ingredientsTxt;
    public Text toppingsTxt;
    #endregion

    public void SetTeaBaseText(string b) {
        if (teaBaseTxt.text == "") {
            teaBaseTxt.text = b;
        }
    }

}
