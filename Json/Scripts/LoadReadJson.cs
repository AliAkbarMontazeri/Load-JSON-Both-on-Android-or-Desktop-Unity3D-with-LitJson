using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class LoadReadJson : MonoBehaviour {

    private List<ValueTest> _database = new List<ValueTest>();
    private JsonData _itemData;

    public int valueItem;

    void Start() {
        //if(Application.platform == RuntimePlatform.Android){
        //    //StartCoroutine("Mobile");
        //    ReadJSONMobile();
        //}
        //else if(Application.isEditor){
        //    if(File.Exists(Application.streamingAssetsPath + "/ValueTest.json")){
        //        Debug.Log("Ada");
        //    }
        //    _itemData = JsonMapper.ToObject(File.ReadAllText(Application.streamingAssetsPath + "/ValueTest.json"));
        //}
        ReadJSONMobile();
        ConstructItemDatabase();
        Debug.Log(valueItem);
    }

    IEnumerator Mobile() {
        WWW loadDb = new WWW(Application.streamingAssetsPath + "/ValueTest.json");
        yield return loadDb;
        File.WriteAllBytes(Application.persistentDataPath + "/ValueTest.json", loadDb.bytes);
        _itemData = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/ValueTest.json"));
    }

    void ReadJSONMobile() {
        TextAsset file = Resources.Load("ValueTest") as TextAsset;
        string content = file.ToString();
        _itemData = JsonMapper.ToObject(content);
    }

    void ConstructItemDatabase() { 
        for(int i = 0; i < _itemData.Count; i++){
            _database.Add(new ValueTest(
                (int)_itemData[i]["id"], _itemData[i]["title"].ToString(), (int)_itemData[i]["value"]));
        }
        valueItem = _itemData.Count;
    }

    public ValueTest FetchItemByID(int id) {
        for(int i = 0; i < _database.Count; i++){
            if(_database[i].Id == id){
                return _database[i];
            }
        }
        return null;
    }
}

public class ValueTest{
    
    public int Id { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }

    public ValueTest(int id, string title1, int value1) {
        this.Id = id;
        this.Title = title1;
        this.Value = value1;
    }

    public ValueTest() { 
    
    }
}
