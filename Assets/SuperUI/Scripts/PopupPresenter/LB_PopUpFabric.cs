
namespace LB.SuperUI.PopUpSystem 
{
    using UnityEngine;
    using LB.SuperUI.Pool;

    [RequireComponent(typeof(LB_Pool))]
    public class LB_PopUpFabric : MonoBehaviour
    {
        private LB_Pool pool;

        public void InitializeFabric()
        {
            pool = GetComponent<LB_Pool>();
            pool.PopulatePool(3);
        }

        public LB_PopUp GetPopUp(PopUpSettings popUpSettings)
        {
            var popUpTemplate = pool.GetPoolable();
            popUpTemplate.ApplySettings(popUpSettings);
            return popUpTemplate as LB_PopUp;
        }

        public void PopUpRecycled(LB_Poolable popUp)
        {
            pool.AddObjectToPool(popUp);
        }
    }

    public struct PopUpSettings
    {
        public PopUpType Type;
        public bool hasOkeyButton;
        public bool hasCancelButton;
        public bool hasCloseButton;
        public string Title;
        public string Content;
    }

}
