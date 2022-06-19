using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class getItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public IEnumerator GetIte_m(string itemID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unitybackend/GetItem.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            } 
            else
            {
                //byte[] results = www.downloadHandler.data;
                Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                string jsonArray = www.downloadHandler.text;
                callback(jsonArray);
            }
        }
    }

    public IEnumerator sellite_m(string itemID,string userID)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);
        form.AddField("userID", userID);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unitybackend/SellItem.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                //string jsonArray = www.downloadHandler.text;
                //callback("");
            }
        }
    }
}
