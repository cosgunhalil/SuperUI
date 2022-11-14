namespace VoxelPixel.SampleApp
{
    using LB.SuperUI.BaseComponents;
    using UnityEngine;

    public class SampleApp : MonoBehaviour
    {
        private LB_UIManager superUI;
        // Start is called before the first frame update
        void Start()
        {
            superUI = GameObject.FindObjectOfType<LB_UIManager>();
#if UNITY_EDITOR
            if (superUI == null) 
            {
                Debug.LogError("There is no LB_UIManager in the scene. Please add one!");
            }
#endif
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                superUI.EnableCanvas(UIState.MAIN_MENU);
            }
            else if (Input.GetKeyDown(KeyCode.W)) 
            {
                superUI.EnableCanvas(UIState.MARKET);
            }
            else if (Input.GetKeyDown(KeyCode.E)) 
            {
                superUI.EnableCanvas(UIState.CHARACTERS);
            }            
            else if (Input.GetKeyDown(KeyCode.T))
            {
                superUI.EnableCanvas(UIState.EVENTS);
            }
        }
    }
}
