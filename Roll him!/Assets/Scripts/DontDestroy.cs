using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    static private GameObject firstInstance = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (firstInstance == null)
        {
            firstInstance = gameObject;
        }
            

        else if (gameObject != firstInstance)
        {
            Destroy(gameObject);
        }
            
    }
}
