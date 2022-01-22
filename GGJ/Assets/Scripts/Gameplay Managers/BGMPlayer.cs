using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public BGMPlayer instance;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
