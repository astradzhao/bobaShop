using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrderManager : MonoBehaviour
{
    public Button takeOrderBtn;
    public static List<Order> orderList;
    public GameObject drinkManager;
    public static OrderManager singleton;
    public Sprite orderDoneSprite;
    private List<Drink> drinksOnOrderScene;

    private void Awake() {
        if (singleton == null)
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
            orderList = new List<Order>();
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
        drinksOnOrderScene = new List<Drink>();
        drinkManager = GameObject.Find("DrinkManager");
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "OrderScene") {
            takeOrderBtn = GameObject.Find("Take Order").GetComponent<Button>();
        }
        CheckDrinks();
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



    public void AddOrder(Order newOrder) {
        orderList.Add(newOrder);
        print(orderList.Count);
    }

    public void RemoveOrder(Order completedOrder) {
        orderList.Remove(completedOrder);
    }

    private void CheckDrinks() {
        drinksOnOrderScene = DrinkManager.GetDrinkList("OrderScene");
        for (int i = 0; i < orderList.Count; i++) {
            Order currOrder = orderList[i];
            for (int j = 0; j < drinksOnOrderScene.Count; j++) {
                Drink currDrink = drinksOnOrderScene[j];
                if (currOrder.equalsDrink(currDrink)) {
                     takeOrderBtn.image.sprite = orderDoneSprite;
                }
            }
        }
    }



}
