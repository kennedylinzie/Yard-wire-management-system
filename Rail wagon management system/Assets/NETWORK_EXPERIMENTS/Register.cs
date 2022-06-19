using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Register : MonoBehaviour
{
    void Start()
    {
       // StartCoroutine(Registe_r("jonas", "987654",23,2));
    }

   public IEnumerator Registe_r(string username, string password, int coins, int level)
    {
        WWWForm form = new WWWForm();
        form.AddField("regUsername", username);
        form.AddField("regPassword", password);
        form.AddField("regCoins", coins);
        form.AddField("regLevel", level);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unitybackend/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

            }
        }
    }
}
