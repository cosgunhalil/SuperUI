
namespace LB.SuperUI.Editor 
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class PanelJsonData
    {
        public string Name;
        public List<UIObjectJsonData> uiObjectDataList;

        public PanelJsonData() 
        {
            uiObjectDataList = new List<UIObjectJsonData>();
        }

        public void AddUIObject(UIObjectJsonData uIObjectJsonData)
        {
            uiObjectDataList.Add(uIObjectJsonData);
        }

        public void RemoveUIObject(string uiObjectName) 
        {
            for (int i = 0; i < uiObjectDataList.Count; i++)
            {
                if (uiObjectDataList[i].Name == uiObjectName) 
                {
                    uiObjectDataList.RemoveAt(i);
                }
            }
        }

        //TODO: write generic function!!!
        public void RemoveUIObject(int index)
        {
            if (index >= uiObjectDataList.Count)
            {
                return;
            }

            if (index < 0)
            {
                return;
            }

            uiObjectDataList.RemoveAt(index);
        }

        public List<UIObjectJsonData> GetUIObjectList() 
        {
            return uiObjectDataList;
        }
    }
}


