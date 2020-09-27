
namespace LB.SuperUI.Pool 
{
    public interface LB_Poolable
    {
        void OnActivated();
        void OnDeactivate();
        void Initialize();
        void ApplySettings(object info);
    }
}
