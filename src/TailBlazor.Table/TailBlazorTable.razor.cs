using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace TailBlazor.Table
{
    public partial class TailBlazorTable
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Class { get; set; } = "min-w-full";
    }
}
