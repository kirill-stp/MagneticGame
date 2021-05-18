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

    protected void Awake()
    {
        if (instance != null)
        {
            // небольшой костыль, т.к. объект не успевал удалиться к началу DI в LevelManager.
            // Работает еще метод DestroyImmediate, но в документации написно,
            // что его очень нежелательно использовать
            gameObject.SetActive(false);
            Destroy(gameObject);

            return;
        }

        instance = this as T;
        DontDestroyOnLoad(gameObject);
    }

    #endregion
}
