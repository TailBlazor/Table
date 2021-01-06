using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace TailBlazor.Table
{
    public partial class TailBlazorTableBody<TItem>
        where TItem : ITailBlazorTableModel
    {
        [Parameter] public RenderFragment<TItem> RowContent { get; set; }
        [Parameter] public RenderFragment<TItem> ChildRowContent { get; set; }
        [Parameter] public IEnumerable<TItem> Items { get; set; }
        [Parameter] public string Class { get; set; } = "bg-white divide-y divide-gray-300";
        [Parameter] public bool StripeRows { get; set; } = true;
        List<TItem> _items = new List<TItem>();
        protected override void OnParametersSet()
        {
            _items = Items.ToList();
        }
    }
}