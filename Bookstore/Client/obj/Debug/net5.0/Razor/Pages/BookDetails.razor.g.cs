#pragma checksum "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb690316d3648e7ddabd1015e0878815346bfd0d"
// <auto-generated/>
#pragma warning disable 1591
namespace Bookstore.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using Bookstore.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using Bookstore.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
using Bookstore.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/details/{id}")]
    public partial class BookDetails : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 8 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
 if (book == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 11 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<h1><b>Details:</b></h1>\r\n    ");
            __builder.AddMarkupContent(2, "<p style=\"text-align: right; margin: 0;\"><button class=\"comments\"></button>\r\n        <span style=\"padding-left: 20px\"></span>\r\n        <button class=\"cart\"></button></p>\r\n    ");
            __builder.OpenElement(3, "table");
            __builder.AddAttribute(4, "class", "normal");
            __builder.OpenElement(5, "tr");
            __builder.AddAttribute(6, "class", "normal");
            __builder.OpenElement(7, "td");
            __builder.AddAttribute(8, "class", "normal");
            __builder.OpenElement(9, "table");
            __builder.OpenElement(10, "tr");
            __builder.OpenElement(11, "td");
#nullable restore
#line 26 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
                             if (!book.isAvailable())
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(12, "p");
            __builder.AddAttribute(13, "style", "color: #a6a6a6");
#nullable restore
#line 29 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(14, book.Status);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 31 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(15, "p");
            __builder.AddAttribute(16, "style", "color: #6600ff");
#nullable restore
#line 35 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(17, book.Status);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                                ");
            __builder.OpenElement(19, "p");
            __builder.AddMarkupContent(20, "\r\n                                    Available amount: ");
#nullable restore
#line 38 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(21, book.Amount);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 40 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
                            }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(22, "p");
            __builder.AddMarkupContent(23, "\r\n                                Price: ");
#nullable restore
#line 42 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(24, book.Price);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(25, " USD\r\n                            ");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n                    ");
            __builder.OpenElement(27, "tr");
            __builder.OpenElement(28, "td");
            __builder.AddMarkupContent(29, "<p>Genres:</p>");
#nullable restore
#line 49 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
                             foreach (var genre in book.Genres)
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(30, "p");
#nullable restore
#line 51 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(31, genre);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 52 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
                            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n            ");
            __builder.OpenElement(33, "td");
            __builder.AddAttribute(34, "class", "normal");
            __builder.AddAttribute(35, "style", "width: 75%");
            __builder.OpenElement(36, "table");
            __builder.OpenElement(37, "tr");
            __builder.OpenElement(38, "td");
            __builder.AddAttribute(39, "class", "image");
            __builder.OpenElement(40, "img");
            __builder.AddAttribute(41, "src", 
#nullable restore
#line 61 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
                                       book.Cover

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n                        ");
            __builder.OpenElement(43, "td");
            __builder.AddAttribute(44, "style", "width: 50%");
#nullable restore
#line 64 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
                             if (book.Series != null)
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(45, "p");
            __builder.AddAttribute(46, "style", "font-size: 50px");
#nullable restore
#line 66 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(47, book.Series);

#line default
#line hidden
#nullable disable
            __builder.AddContent(48, " vol ");
#nullable restore
#line 66 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(49, book.Number);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 67 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
                            }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(50, "p");
            __builder.AddAttribute(51, "style", "font-size: 50px");
#nullable restore
#line 68 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(52, book.Title);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n                            ");
            __builder.OpenElement(54, "p");
            __builder.AddAttribute(55, "style", "font-size: 40px");
            __builder.AddContent(56, "Authors: ");
#nullable restore
#line 69 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(57, string.Join(", ", book.Authors));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n                            ");
            __builder.OpenElement(59, "p");
            __builder.AddAttribute(60, "style", "font-size: 30px");
            __builder.AddContent(61, "Year:  ");
#nullable restore
#line 70 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(62, book.Year);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n                            ");
            __builder.OpenElement(64, "p");
            __builder.AddAttribute(65, "style", "font-size: 30px");
            __builder.AddContent(66, "Original Language:  ");
#nullable restore
#line 71 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(67, book.Language);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n                            ");
            __builder.OpenElement(69, "p");
            __builder.AddAttribute(70, "style", "font-size: 30px");
            __builder.AddContent(71, "Publisher: ");
            __builder.OpenElement(72, "a");
            __builder.AddAttribute(73, "href", 
#nullable restore
#line 72 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
                                                                            book.Publisher.WebAddress

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 72 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
__builder.AddContent(74, book.Publisher.Name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 79 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(75, "<style>\r\n\r\n    img {\r\n        width: 80%;\r\n        height: 80%;\r\n    }\r\n\r\n    .image {\r\n        width: 50%;\r\n        height: 50%;\r\n    }\r\n\r\n    table.normal {\r\n        border-style: none;\r\n        border-right-style: none;\r\n        border-left-style: none;\r\n    }\r\n\r\n    td.normal {\r\n        border-style: none;\r\n    }\r\n\r\n        td.normal:first-child {\r\n            border-style: none;\r\n            border-right-style: none;\r\n            border-left-style: none;\r\n        }\r\n\r\n        td.normal:last-child {\r\n            border-style: none;\r\n            border-right-style: none;\r\n            border-left-style: none;\r\n        }\r\n\r\n    h1 {\r\n        text-align: center;\r\n        font-family: \'Poppins\', sans-serif;\r\n    }\r\n\r\n    .outside {\r\n        width: 100%;\r\n        border-collapse: separate;\r\n        table-layout: fixed;\r\n    }\r\n\r\n    table {\r\n        width: 100%;\r\n        border-collapse: separate;\r\n        border-spacing: 0 10px;\r\n        margin-left: auto;\r\n        margin-right: auto;\r\n        table-layout: fixed;\r\n    }\r\n\r\n    tr {\r\n        border-spacing: 10px;\r\n        vertical-align: top;\r\n        text-align: left;\r\n        font-family: \'Poppins\', sans-serif;\r\n        font-weight: bold;\r\n        font-size: 20px;\r\n        padding: 10px;\r\n    }\r\n\r\n    td {\r\n        border: 2px solid;\r\n        border-style: solid none;\r\n        border-color: #a6a6a6;\r\n        padding: 11px;\r\n    }\r\n\r\n    .buttons {\r\n        width: 20%;\r\n    }\r\n\r\n    td:first-child {\r\n        border-left-style: solid;\r\n        border-top-left-radius: 11px;\r\n        border-bottom-left-radius: 11px;\r\n        border-color: #a6a6a6;\r\n    }\r\n\r\n    td:last-child {\r\n        border-right-style: solid;\r\n        border-bottom-right-radius: 11px;\r\n        border-top-right-radius: 11px;\r\n        border-color: #a6a6a6;\r\n    }\r\n\r\n    td {\r\n        padding: 20px;\r\n    }\r\n\r\n        td.image {\r\n            width: 230px;\r\n        }\r\n\r\n    button {\r\n        padding: 0px;\r\n        border: none;\r\n        border-radius: 50%;\r\n    }\r\n\r\n    .details {\r\n        background-image: url(/Images/InactiveArrow.PNG);\r\n        background-size: cover;\r\n        width: 75px;\r\n        height: 75px;\r\n    }\r\n\r\n        .details:hover {\r\n            background-image: url(/Images/ActiveArrow.PNG);\r\n            background-size: cover;\r\n            width: 75px;\r\n            height: 75px;\r\n        }\r\n\r\n    .comments {\r\n        background-image: url(/Images/InactiveComment.PNG);\r\n        background-size: cover;\r\n        width: 75px;\r\n        height: 75px;\r\n    }\r\n\r\n        .comments:hover {\r\n            background-image: url(/Images/ActiveComment.PNG);\r\n            background-size: cover;\r\n            width: 75px;\r\n            height: 75px;\r\n        }\r\n\r\n    .cart {\r\n        background-image: url(/Images/InactiveBasket.PNG);\r\n        background-size: cover;\r\n        width: 75px;\r\n        height: 75px;\r\n    }\r\n\r\n        .cart:hover {\r\n            background-image: url(/Images/ActiveBasket.PNG);\r\n            background-size: cover;\r\n            width: 75px;\r\n            height: 75px;\r\n        }\r\n</style>");
        }
        #pragma warning restore 1998
#nullable restore
#line 81 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Pages\BookDetails.razor"
       
    [Parameter]
    public string id { get; set; }
    private string user { get; set; }
    private BookFull book { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            user = authState.User.Identity.Name;
            book = await Http.GetFromJsonAsync<BookFull>($"/details/{id}");
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591