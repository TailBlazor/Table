namespace TailBlazor.Table
{
    public interface ITailBlazorTableModel
    {
        string RowClass { get; }
        string ChildRowClass { get; }
        bool ShowChildTemplate { get; }
    }
}
