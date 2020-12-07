
namespace LB.SuperUI.Editor 
{
    using System;
    using System.Collections.Generic;
    [Serializable]
    public class SceneJsonData
    {
        public string UIManagerName;
        public List<PanelJsonData> panelDataList;

        public SceneJsonData() 
        {
            UIManagerName = "UIManager";
            panelDataList = new List<PanelJsonData>();
        }

        public void AddPanelData(PanelJsonData panelJsonData)
        {
            panelDataList.Add(panelJsonData);
        }

        public void RemovePanelData(string panelName) 
        {
            for (int i = 0; i < panelDataList.Count; i++)
            {
                if (panelDataList[i].Name == panelName) 
                {
                    panelDataList.RemoveAt(i);
                }
            }
        }

        public void RemovePanelData(int panelIndex) 
        {
            if (panelIndex >= panelDataList.Count) 
            {
                return;
            }

            if (panelIndex < 0) 
            {
                return;
            }

            panelDataList.RemoveAt(panelIndex);
        }

        public void ClearPanelData() 
        {
            panelDataList.Clear();
        }

        public List<PanelJsonData> GetPanelDataList()
        {
            return panelDataList;
        }
    }
}

