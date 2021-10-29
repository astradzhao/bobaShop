using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink
{
    #region Instance Variables
    private string teaBase;
    private List<string> ingredients;
    private List<string> toppings;
    private string ingredientsText;
    private string toppingsText;
    #endregion 

    #region Instantiation
    public Drink() {
        this.teaBase = null;
        this.ingredients = new List<string>();
        this.toppings = new List<string>();
        this.ingredientsText = "";
        this.toppingsText = "";
    }
    #endregion
    
    #region GameFunctions
    public void changeTeaBase(string b) {
        if(this.teaBase == null) {
            this.teaBase = b;
        }
    }

    public void addIngredient(string i) {
        this.ingredients.Add(i);
        if (this.ingredientsText == "") {
            this.ingredientsText += i;
        }
        else {
            this.ingredientsText += ", " + i;
        }
    }

    public void addToppings(string t) {
        this.toppings.Add(t);
        if (this.toppingsText == "") {
            this.toppingsText += t;
        }
        else {
            this.toppingsText += ", " + t;
        }
    }
    #endregion

    #region GetFunctions
    public string getBase() {
        return this.teaBase;
    }
    public List<string> getIngredients() {
        return this.ingredients;
    }

    public List<string> getToppings() {
        return this.toppings;
    }

    public string getIngText() {
        return this.ingredientsText;
    }

    public string getTopText() {
        return this.toppingsText;
    }
    #endregion

    public override bool Equals(object obj)
    {
        Drink o = obj as Drink;
        if (o == null) {
            return false;
        }
        return this.GetHashCode() == o.GetHashCode();
    }

    public override int GetHashCode()
    {
        int hash = 0;
        for (int i = 0; i < this.toppings.Count; i++) {
            hash += i + this.toppings[i].GetHashCode() * (i + 11);
        }
        for (int i = 0; i < this.ingredients.Count; i++) {
            hash += i * 2 + this.ingredients[i].GetHashCode() * (i + 17);
        }
        return hash + this.teaBase.GetHashCode() * 13;
    }
}
