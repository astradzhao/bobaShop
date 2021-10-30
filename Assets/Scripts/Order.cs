using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : Object
{
    #region Private Class Variables
    private static List<string> allTeaBases = new List<string>{"Thai", "Green", "Black", "Rose"};
    private static List<string> allIngredients = new List<string>{"Fruits", "Taro", "Ice", "Milk"};
    private static List<string> allToppings = new List<string>{"Lychee jelly", "Tapioca pearls", "Strawberry stars"};
    private static int allOrderNums;
    #endregion

    #region Private Instance Variables
    private int numIngredients;
    private int numToppings;
    private int orderNum;
    private string teaBase;
    private List<string> ingredients;
    private List<string> toppings;
    #endregion

    #region Start Functions
    private void Start() {
        allOrderNums = 0;
    }
    #endregion

    #region Instantiation
    // Instantiate a new order
    public Order() {
        allOrderNums += 1;
        this.orderNum = allOrderNums;
        this.teaBase = allTeaBases[Random.Range(0, allTeaBases.Count)];
        this.ingredients = new List<string>();
        this.toppings = new List<string>();

        // Number of Ingredients and toppings. Max for both is set to 2
        numIngredients = Random.Range(1, 3);
        numToppings = Random.Range(1, 3);

        // Assign ingredients
        while (this.ingredients.Count < numIngredients) {
            string newIng = allIngredients[Random.Range(0, allTeaBases.Count)];
            if (!this.ingredients.Contains(newIng)) {
                this.ingredients.Add(newIng);
            }
        }

        // Assign toppings
        while (this.toppings.Count < numToppings) {
            string newTop = allToppings[Random.Range(0, allToppings.Count)];
            if (!this.toppings.Contains(newTop)) {
                this.toppings.Add(newTop);
            }
        }
    }
    #endregion

    #region Get Functions
    public int GetOrderNum() {
        return this.orderNum;
    }

    public string GetTeaBase() {
        return this.teaBase;
    }

    public List<string> GetIngredients() {
        return this.ingredients;
    }

    public List<string> GetToppings() {
        return this.toppings;
    }
    #endregion
}
