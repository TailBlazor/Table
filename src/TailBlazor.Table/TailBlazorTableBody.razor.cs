using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace TailBlazor.Table
{
    public partial class TailBlazorTableBody<TItem>
        where TItem : ITailBlazorTableModel
    {
        [Parameter, EditorRequired]
        public RenderFragment<TItem> RowContent { get; set; } = default!;

        [Parameter]
        public RenderFragment<TItem>? ChildRowContent { get; set; }

        [Parameter]
        public IEnumerable<TItem> Items { get; set; } = Array.Empty<TItem>();

        [Parameter]
        public string Class { get; set; } = "bg-white divide-y divide-gray-300";

        [Parameter]
        public bool StripeRows { get; set; } = true;

        private List<TItem> _items = new();

        protected override void OnParametersSet()
        {
            _items = (Items ?? Enumerable.Empty<TItem>()).ToList();
        }
    }
}

