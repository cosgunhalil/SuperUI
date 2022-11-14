
namespace LB.SuperUI.BaseComponents 
{
    using System.Collections;
    using LB.SuperUI.Sample;
    using UnityEngine;
    using VoxelPixel.SampleApp.UI;

    public class LB_UIManager : MonoBehaviour
    {
        private LB_UIPanel[] panels;

        [SerializeField] 
        private MainMenuPanel mainMenuPanel;
        [SerializeField] 
        private CommonsPanel commonsPanel;
        [SerializeField] 
        private CharactersPanel charactersPanel;
        [SerializeField] 
        private EventsPanel eventsPanel;
        [SerializeField] 
        private MarketPanel marketPanel;

        private LB_UIPanel activeCanvas = null;

        public void Awake()
        {
            panels = new LB_UIPanel[(int)UIState.COUNT];
            panels[(int)UIState.MAIN_MENU] = mainMenuPanel;
            panels[(int)UIState.COMMONS] = commonsPanel;
            panels[(int)UIState.CHARACTERS] = charactersPanel;
            panels[(int)UIState.EVENTS] = eventsPanel;
            panels[(int)UIState.MARKET] = marketPanel;

            for (int i = 0; i < panels.Length; ++i)
            {
                panels[i].PreInit();
            }
        }

        public void Start()
        {
            for (int i = 0; i < panels.Length; ++i)
            {
                panels[i].Init();
                panels[i].LateInit();
            }
        }

        public void OnDestroy()
        {
            for (int i = 0; i < panels.Length; ++i)
            {
                panels[i].OnDestroyCalled();
            }
        }

        public void EnableCanvas(UIState canvasType)
        {

            LB_UIPanel targetCanvas = null;
            switch (canvasType)
            {
                case UIState.CHARACTERS:
                    targetCanvas = charactersPanel;
                    break;
                case UIState.MAIN_MENU:
                    targetCanvas = mainMenuPanel;
                    break;
                case UIState.MARKET:
                    targetCanvas = marketPanel;
                    break;
                case UIState.EVENTS:
                    targetCanvas = eventsPanel;
                    break;
                case UIState.COMMONS:
                case UIState.COUNT:
                    targetCanvas = commonsPanel;
                    break;
            }

            if (activeCanvas == null)
            {
                activeCanvas = targetCanvas;
                activeCanvas.Activate();
                return;
            }

            if (activeCanvas == targetCanvas) 
            {
                return;
            }

            StopCoroutine("EnableRequestedCanvas");
            StartCoroutine("EnableRequestedCanvas", targetCanvas);
        }

        private IEnumerator EnableRequestedCanvas(LB_UIPanel targetCanvas)
        {
            if (activeCanvas != null)
            {
                activeCanvas.Deactivate();
            }

            yield return new WaitForSeconds(.5f);

            activeCanvas = targetCanvas;
            activeCanvas.Activate();
        }
    }
}

