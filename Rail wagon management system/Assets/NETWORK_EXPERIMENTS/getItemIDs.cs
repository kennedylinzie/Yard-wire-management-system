using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class getItemIDs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public IEnumerator GetItem_IDS(string userid,System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userid);
       

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unitybackend/GetItemsIDs.php",form))
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
}
