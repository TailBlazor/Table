# TailBlazor.Table

#### Update
I refactored to push Table more in line with how the other elements are done. Please see changes below.

Blazor Table a basic yet customizable table component for Tailwindcss

Without passing it anything you'll get very basic styles, however giving it it's base classes and you can really make a customizable table that Tailwind is capable of.



![Nuget](https://img.shields.io/nuget/v/TailBlazor.Table.svg)

![Demo](screenshot.png)

## Getting Setup

You can install the package via the NuGet package manager just search for TailBlazor.Table. You can also install via powershell using the following command.

`Install-Package TailBlazor.Table`

Or via the dotnet CLI.

`dotnet add package TailBlazor.Table`

### 1. Add Imports

Add line to your \_Imports.razor

```
@using TailBlazor.Table
```

### 2. Create Table Component

Inside your page create your table component with the basic format below. For table styles, use the `class` parameter. By default default styles are applied. If you choose to override you'll be given blank styles for each section.

```html
<TailBlazorTableTemplate class="divide-gray-200">
    <TailBlazorTableHeader>
        ...
    </TailBlazorTableHeader>
    <TailBlazorTableBody>
        ...
    </TailBlazorTableBody>
</TailBlazorTableTemplate>
```

### 3. Adding the table headers

for each table header add it's own `<th></th>` with optional styles.

You can also configure the thead styles using the `class` parameter just like the Table Component

```html
<TailBlazorTable>
    <TailBlazorTableHeader class="p-4 bg-gray-50">
        <th class="px-4 py-3 text-left text-sm font-medium text-gray-700">Employee Id</th>
        <th class="px-4 py-3 text-left text-sm font-medium text-gray-700">First name</th>
        <th class="px-4 py-3 text-left text-sm font-medium text-gray-700">Last name</th>
        <th class="px-4 py-3 text-left text-sm font-medium text-gray-700">Email</th>
        <th class="px-4 py-3 text-left text-sm font-medium text-gray-700">Contractor</th>
    </TailBlazorTableHeader>
    ...
```

### 4. Creating your model

To get your `context` you'll have to add the `Items` which is an IEnumerable<TItem>. You'll want to have the class you want to pass in inherit the `ITailBlazorTableModel`.

```csharp
public class MyClass : ITailBlazorTableModel
{
    ...
}
```

You'll need to implement the classes. For the `ShowChildTemplate`. This allows you to show an additional row on some sort of trigger. More about below in section 6.

By default your object is accessible via the `context` parameter. You can however rename that via `Context=NewContextName`. Type inference is great but sometimes it doesn't quite get it right. You may also need to pass the table the type `TItem=YourClass`.

You can also like above, pass the tablebody component your styles like so `class="bg-blue-400"`

```html
<TailBlazorTable>
    <TailBlazorTableBody Context="NewContextName" TItem=YourClass Items=youClassList class="bg-blue-400">
        <RowContent>
            <td class="text-gray-700">@NewContextName.Id</td>
            <td class="text-gray-700">@NewContextName.FirstName</td>
            <td class="text-gray-700">@NewContextName.LastName</td>
            <td class="text-gray-700">@NewContextName.Email</td>
            <td class="text-gray-700">@(NewContextName.IsContractor ? "Yes" : "No")</td>
        </RowContent>
        <ChildRowContent>
        ...
</TailBlazorTable>

```

### 5. More Customization

By default the table is striped. You can disable that by setting `StripeRows=false` inside the TableBody component

```html
<TailBlazorTableBody StripeRows=false>
```

### 6. ChildRow

If you have a row that should expand when a user triggers a button. You have access to the `<ChildTemplate></ChildTemplate>` RenderFragment. Setting `ShowChildTemplate` inside your RowTemplate will show the new table row.

Treat the ChildTemplate the same as RowTemplate created just under the activated row.

Note: There isn't just a property called "ShowChildTemplate". We're assuming this is a bool from a DB or something. If you don't have that it could be as simple as assigning a property to false and then assigning that property to the `ShowChildTemplate` method you implemented above.

```csharp
public class MyClass : ITailBlazorTableModel
{
    ...

    public bool ShowChildTemplate {
        get {
            return ShowChildTemplate;
        }
    }

    public bool ShowChildTemplate { get; set; } = false;

    ...
}

```


```html
<RowContent>
    ...
    <td>
        <a href="" @onclick="e => NewContextName.ShowChildTemplate = !NewContextName.ShowChildTemplate">Open ChildTemplate</a>
    </td>
</RowContent>
 <ChildRowContent>
    <button>Activate Launch Sequence?</button>
</ChildRowContent>
```
