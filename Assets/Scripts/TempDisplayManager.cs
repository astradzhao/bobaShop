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

    public void AddIngredientText(string b) {
        if (ingredientsTxt.text == "") {
            ingredientsTxt.text = b;
        }
        else {
            ingredientsTxt.text += ", " + b;
        }
    }

    public void AddToppingText(string b) {
        if (toppingsTxt.text == "") {
            toppingsTxt.text = b;
        }
        else {
            toppingsTxt.text += ", " + b;
        }
    }

}
