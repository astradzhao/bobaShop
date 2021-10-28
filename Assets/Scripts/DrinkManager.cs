using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrinkManager : MonoBehaviour
{
    public static DrinkManager singleton;

    public GameObject myDrink;
    public Canvas canvas;
    private static Dictionary<string, List<Drink>> drinks;

    private void Awake() {
        if (singleton != null && singleton != this) 
        {
            Destroy(this.gameObject);
            drinks = new Dictionary<string, List<Drink>>();
            drinks.Add("OrderScene", new List<Drink>());
            drinks.Add("TeaBaseScene", new List<Drink>());
            drinks.Add("IngredientsScene", new List<Drink>());
            drinks.Add("MixingScene", new List<Drink>());
            drinks.Add("SealingScene", new List<Drink>());
            newDrink();
        }
        if (singleton == null) {
            drinks = new Dictionary<string, List<Drink>>();
            drinks.Add("OrderScene", new List<Drink>());
            drinks.Add("TeaBaseScene", new List<Drink>());
            drinks.Add("IngredientsScene", new List<Drink>());
            drinks.Add("MixingScene", new List<Drink>());
            drinks.Add("SealingScene", new List<Drink>());
            newDrink();
        }
        singleton = this;
        string sceneName = SceneManager.GetActiveScene().name;
        if (drinks[sceneName].Count == 0) {
            myDrink = null;
        }
        else {
            print(drinks[sceneName].Count);
            Drink d = drinks[sceneName][0];
            Instantiate(myDrink, new Vector3(-800, -875, 0), Quaternion.identity);
            myDrink.transform.parent = canvas.transform;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void addDrink(Drink d, string station) {
        drinks[station].Add(d);
    }

    public void newDrink() {
        Drink d = new Drink();
        print(d);
        drinks["TeaBaseScene"].Add(d);
    }

    public List<Drink> getStationDrinks(string station) {
        return drinks[station];
    }

    public void addIngredient(string i) {
        if (myDrink != null) {
            myDrink.addIngredient(i);
        }
    }

    public void addToppings(string t) {
        if (myDrink != null) {
            myDrink.addToppings(t);
        }
    }

    public void changeTeaBase(string b) {
        if (myDrink != null) {
            myDrink.changeTeaBase(b);
        }
    }
}
