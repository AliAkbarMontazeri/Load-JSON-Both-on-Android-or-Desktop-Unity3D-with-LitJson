using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowData : MonoBehaviour {

    public Text[] showTitle = new Text[4];
    public Text[] showValue = new Text[4];

    LoadReadJson _database;

    void Start() {
        _database = GetComponent<LoadReadJson>();
    }

    public void DoShow() { 
        for (int i = 0; i < _database.valueItem; i++){
            Show(i);
        }
    }

    void Show(int id) {
        ValueTest valueToAdd = _database.FetchItemByID(id);
        
        switch(id){
            case 0:
                showTitle[id].text = valueToAdd.Title;
                showValue[id].text = valueToAdd.Value.ToString();
                break;
            case 1:
                showTitle[id].text = valueToAdd.Title;
                showValue[id].text = valueToAdd.Value.ToString();
                break;
            case 2:
                showTitle[id].text = valueToAdd.Title;
                showValue[id].text = valueToAdd.Value.ToString();
                break;
            case 3:
                showTitle[id].text = valueToAdd.Title;
                showValue[id].text = valueToAdd.Value.ToString();
                break;
        }
    }
}
