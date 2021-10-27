using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkManager : MonoBehaviour
{
    public static DrinkManager singleton;
    private static Dictionary<string, List<Drink>> drinks = new Dictionary<string, List<Drink>>();

    private void Awake() {
        if (singleton != null && singleton != this) 
         {
            Destroy(this.gameObject);
            drinks["order"] = new List<Drink>();
            drinks["bases"] = new List<Drink>();
            drinks["ingredients"] = new List<Drink>();
            drinks["mixing"] = new List<Drink>();
            drinks["sealing"] = new List<Drink>();
         }
         if (singleton == null) {
            drinks["order"] = new List<Drink>();
            drinks["bases"] = new List<Drink>();
            drinks["ingredients"] = new List<Drink>();
            drinks["mixing"] = new List<Drink>();
            drinks["sealing"] = new List<Drink>();
         }
         singleton = this;
         DontDestroyOnLoad(this.gameObject);
    }
    public void addDrink(Drink d, string station) {
        drinks[station].Add(d);
    }

    public void newDrink() {
        Drink d = new Drink();
        drinks["bases"].Add(d);
    }

    public List<Drink> getStationDrinks(string station) {
        return drinks[station];
    }
}
