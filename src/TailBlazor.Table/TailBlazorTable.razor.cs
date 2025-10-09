using Microsoft.AspNetCore.Components;

namespace TailBlazor.Table
{
    public partial class TailBlazorTable
    {
        [Parameter, EditorRequired]
        public RenderFragment ChildContent { get; set; } = default!;

        [Parameter]
        public string Class { get; set; } = "min-w-full";
    }
}

