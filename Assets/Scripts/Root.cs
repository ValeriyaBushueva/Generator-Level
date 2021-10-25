using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private GenerateLevelView _generateLevelView;

    private void Awake()
    {
        var controller = new GenerateLevelController(_generateLevelView);
        controller.Awake();
    }
}
