using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DrinkManager : MonoBehaviour
{
    public static DrinkManager singleton;
    public GameObject myDrink;
    public GameObject currObject;
    public Canvas canvas;
    private static Dictionary<string, List<Drink>> drinks;

    private void Awake() {
        if (singleton == null)
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
            drinks = new Dictionary<string, List<Drink>>();
            drinks.Add("OrderScene", new List<Drink>());
            drinks.Add("TeaBaseScene", new List<Drink>());
            drinks.Add("IngredientsScene", new List<Drink>());
            drinks.Add("MixingScene", new List<Drink>());
            drinks.Add("SealingScene", new List<Drink>());
            newDrink();
        }
        else if (singleton != this)
        {
            Destroy (gameObject);
        }
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        newDrink();
        reloadObject();
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void reloadObject() {
        string sceneName = SceneManager.GetActiveScene().name;
        if (drinks[sceneName].Count == 0) {
            return;
        }
        else {
            Drink sceneD = drinks[sceneName][0];
            DrinkComponent d = myDrink.GetComponent<DrinkComponent>();
            canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            d.drink = sceneD;
            RectTransform r = canvas.GetComponent<RectTransform>();
            float x = r.position.x;
            float y = r.position.y;
            float h = r.rect.height;
            currObject = Instantiate(myDrink, new Vector3(x, y - h/3, 0), Quaternion.identity);
            currObject.transform.SetParent(canvas.transform);
            reloadText(d.drink);
        }
    }

    public void reloadText(Drink d) {
        Text teaBaseTxt = GameObject.Find("BaseText").GetComponent<Text>();
        if (d.getBase() == null) {
            teaBaseTxt.text = "";
        }
        else {
            teaBaseTxt.text = d.getBase();
        }

        Text ingredientsTxt = GameObject.Find("IngredientsText").GetComponent<Text>();
        ingredientsTxt.text = d.getIngText();

        Text toppingsTxt = GameObject.Find("ToppingsText").GetComponent<Text>();
        toppingsTxt.text = d.getTopText();
    }
    public void addDrink(Drink d, string station) {
        drinks[station].Add(d);
    }

    public void newDrink() {
        if (drinks["TeaBaseScene"].Count <= 0) {
            Drink d = new Drink();
            drinks["TeaBaseScene"].Add(d);
        }
    }

    public List<Drink> getStationDrinks(string station) {
        return drinks[station];
    }

    public void addIngredient(string i) {
        if (myDrink != null) {
            DrinkComponent d = myDrink.GetComponent<DrinkComponent>();
            d.drink.addIngredient(i);
            AddIngredientText(i, d.drink);
        }
        else {
            AddIngredientText(i, null);
        }
    }

    public void addToppings(string t) {
        if (myDrink != null) {
            DrinkComponent d = myDrink.GetComponent<DrinkComponent>();
            d.drink.addToppings(t);
            AddToppingText(t, d.drink);
        }
        else {
            AddToppingText(t, null);
        }
    }

    public void changeTeaBase(string b) {
        if (myDrink != null) {
            DrinkComponent d = myDrink.GetComponent<DrinkComponent>();
            d.drink.changeTeaBase(b);
        }
        SetTeaBaseText(b);
    }

    public void SetTeaBaseText(string b) {
        Text teaBaseTxt = GameObject.Find("BaseText").GetComponent<Text>();
        if (teaBaseTxt != null) {
            if (teaBaseTxt.text == "") {
            teaBaseTxt.text = b;
            }
        }
    }

    public void AddIngredientText(string b, Drink d) {
        Text ingredientsTxt = GameObject.Find("IngredientsText").GetComponent<Text>();
        if (ingredientsTxt == null) {
            return;
        }
        if (d == null) {
            ingredientsTxt.text = "";
        }
        else {
            ingredientsTxt.text = d.getIngText();
        }
    }

    public void AddToppingText(string b, Drink d) {
        Text toppingsTxt = GameObject.Find("ToppingsText").GetComponent<Text>();
        if (toppingsTxt == null) {
            return;
        }
        if (d == null) {
            toppingsTxt.text = "";
        }
        else {
            toppingsTxt.text = d.getTopText();
        }
    }

    public void BaseToIng() {
        List<Drink> baseDrinks = drinks["TeaBaseScene"];
        if (baseDrinks.Count <= 0) {
            return;
        }
        Drink d = baseDrinks[0]; 
        baseDrinks.RemoveAt(0);
        drinks["IngredientsScene"].Add(d);
    }

    public void Trash() {
        string sceneName = SceneManager.GetActiveScene().name;
        if (drinks[sceneName].Count >= 1) {
            drinks[sceneName].RemoveAt(0);
        }
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
