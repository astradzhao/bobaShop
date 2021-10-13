using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    #region Instance Variables
    private string teaBase;
    private List<string> ingredients;
    private List<string> toppings;
    #endregion 

    #region Instantiation
    public Drink() {
        this.teaBase = null;
        this.ingredients = new List<string>();
        this.toppings = new List<string>();
    }
    #endregion
    
    #region GameFunctions
    public void changeTeaBase(string b) {
        if(b != null) {
            this.teaBase = b;
        }
    }

    public void addIngredient(string i) {
        this.ingredients.Add(i);
    }

    public void addToppings(string t) {
        this.toppings.Add(t);
    }
    #endregion

    #region GetFunctions
    public string getBase() {
        return this.teaBase;
    }
    #endregion
}
