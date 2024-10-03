using UnityEngine;

public class Persist : MonoBehaviour
{
    private static bool created = false;

    void Start()
    {
        if (!created)
        {
            DontDestroyOnLoad(transform.root.gameObject);
            created = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
