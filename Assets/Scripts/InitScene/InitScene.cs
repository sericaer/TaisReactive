using System.IO;
using Tais.API.Def;
using Tais.GModders;
using Tais.GSessions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitScene : MonoBehaviour
{
    public Button newGame;

    // Start is called before the first frame update
    void Start()
    {
        //GModder.Builder.Build(Path.Combine(Application.streamingAssetsPath, "mods"));

        newGame.onClick.AddListener(() =>
        {
            GSession.Builder.Build(GModder.Default.defs);

            SceneManager.LoadScene(nameof(MainScene));
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
