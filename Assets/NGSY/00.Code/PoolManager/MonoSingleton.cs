using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    _instance = singleton.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        T[] managers = FindObjectsByType<T>(FindObjectsSortMode.None);

        if (managers.Length > 1)
            Destroy(gameObject); //만약 이미 씬에 다른 녀석이 있다면 나를 삭제한다.
    }

    protected void OnDestroy()
    {
        if (_instance == this)
            _instance = null; //내가 파괴되면 인스턴스를 null로 초기화한다.
    }
}
