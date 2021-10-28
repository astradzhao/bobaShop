using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject drinkManager;
    void Start()
    {
        drinkManager = GameObject.Find("DrinkManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Drink functions
    public void addToppings(string s) {
        DrinkManager dm = drinkManager.GetComponent<DrinkManager>();
        dm.addToppings(s);
    }
    public void addIngredient(string s) {
        DrinkManager dm = drinkManager.GetComponent<DrinkManager>();
        dm.addIngredient(s);
    }
    public void changeTeaBase(string s) {
        DrinkManager dm = drinkManager.GetComponent<DrinkManager>();
        dm.changeTeaBase(s);
    }
    public void moveTo(string s) {
        if (s == "IngredientsScene") {
            DrinkManager dm = drinkManager.GetComponent<DrinkManager>();
            dm.BaseToIng();
        }
    }

    public void trashCan() {
        DrinkManager dm = drinkManager.GetComponent<DrinkManager>();
        dm.Trash();
    }
    #endregion
}
