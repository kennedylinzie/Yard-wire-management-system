using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class check_connection : MonoBehaviour
{
    // UnityWebRequest.Get example

    // Access a website and use UnityWebRequest.Get to download a page.
    // Also try to download a non-existing page. Display the error.

    void Start()
    {
        // A correct website page.
        StartCoroutine(GetUsers("http://localhost/unitybackend/GetUsers.php"));

        // A non-existing page.
        StartCoroutine(GetUsers("https://error.html"));
    }

    IEnumerator GetUsers(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
