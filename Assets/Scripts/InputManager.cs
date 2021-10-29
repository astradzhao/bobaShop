using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    #region Public Variables
    public Button takeOrderBtn;
    public Text orderNumTxt;
    public Text teaBaseTxt;
    public Text ingredientsTxt;
    public Text toppingsTxt;
    #endregion


	void Start () {
		takeOrderBtn.onClick.AddListener(DisplayOrder);
	}

	void DisplayOrder() {
		Order newOrder = new Order();
        SetOrderText(newOrder);
	}

    void SetOrderText(Order order) {
        orderNumTxt.text = "Order #" + order.GetOrderNum().ToString();
        teaBaseTxt.text = "";
        ingredientsTxt.text = "";
        toppingsTxt.text = "";

        teaBaseTxt.text = "- " + order.GetTeaBase();
        
        foreach (string ing in order.GetIngredients()) {
            ingredientsTxt.text += "- " + ing + "\n" ;
        }

        foreach (string top in order.GetToppings()) {
            toppingsTxt.text += "- " + top + "\n" ;
        }
    }
}
