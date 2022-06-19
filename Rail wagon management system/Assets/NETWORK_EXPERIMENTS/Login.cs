using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine(Logi_n("kennedy","12345"));
    }

    public IEnumerator Logi_n(string username,string password )
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unitybackend/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.Instance.userInfo.SetCredentials(username,password);
                Main.Instance.userInfo.SetID(www.downloadHandler.text);

                if (www.downloadHandler.text.Contains("User does not exist") || www.downloadHandler.text.Contains("Wrong password"))
                {
                    Debug.Log("Try again");
                }
                else
                {
                    Main.Instance.userProfile.SetActive(true);
                    Main.Instance.loginform.gameObject.SetActive(false);
                }
               
              
            }
        }
    }
}
