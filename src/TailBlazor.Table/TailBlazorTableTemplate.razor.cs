using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace TailBlazor.Table
{
    public partial class TailBlazorTableTemplate<TItem>
        where TItem: ITailBlazorTableModel
    {
        [Parameter]
        public RenderFragment TableHeader { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }

        [Parameter]
        public RenderFragment<TItem> ChildTemplate { get; set; }

        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        [Parameter]
        public string TableClass { get; set; } = "min-w-full";

        [Parameter]
        public string HeaderClass { get; set; } = "bg-gray-50";

        [Parameter]
        public string BodyClass { get; set; } = "bg-white";

        [Parameter]
        public bool StripeRows { get; set; } = true;
    }
}
