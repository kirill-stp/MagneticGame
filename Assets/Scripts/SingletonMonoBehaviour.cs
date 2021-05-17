using System.Security.Cryptography;
using System.Threading.Tasks;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    #region Variables

    private static T instance;

    #endregion


    #region Properties

    public static T Instance => instance;

    #endregion


    #region Unity lifecycle

    protected async void Awake()
    {
        if (instance != null)
        {
            //gameObject.SetActive(false);
            DestroyImmediate(gameObject);

            return;
        }

        instance = this as T;
        DontDestroyOnLoad(gameObject);
    }

    #endregion
}
