using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuUIHandle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
}
