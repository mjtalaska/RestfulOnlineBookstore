#pragma checksum "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "585b65bf6d9de71aa6ae8cb1a76a6fa33ac2c2bb"
// <auto-generated/>
#pragma warning disable 1591
namespace Bookstore.Client.Shared
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
#line 12 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\_Imports.razor"
using Bookstore.Shared.Models;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<head b-2g3gksce56><link rel=""preconnect"" href=""https://fonts.googleapis.com"" b-2g3gksce56>
    <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin b-2g3gksce56>
    <link href=""https://fonts.googleapis.com/css2?family=Poppins:wght@100&display=swap"" rel=""stylesheet"" b-2g3gksce56></head>
");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "page");
            __builder.AddAttribute(3, "b-2g3gksce56");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "main");
            __builder.AddAttribute(6, "b-2g3gksce56");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "upperMenu");
            __builder.AddAttribute(9, "b-2g3gksce56");
            __builder.OpenComponent<Bookstore.Client.Shared.LoginDisplay>(10);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n\r\n        ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "content px-4");
            __builder.AddAttribute(14, "b-2g3gksce56");
#nullable restore
#line 15 "C:\Users\User\Desktop\Homework\S6\MAS\RestfulOnlineBookstore\Bookstore\Client\Shared\MainLayout.razor"
__builder.AddContent(15, Body);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n\r\n");
            __builder.AddMarkupContent(17, @"<style b-2g3gksce56>
    div.upperMenu {
        background-image: url(Images/UpperMenu.PNG);
        background-size: 100%;
        height: 150px;
        background-repeat: no-repeat;
        text-align: right;
    }
    button {
        padding-right: 10px;
        border: none;
        border-radius: 50%;
        margin-top: 1%;
    }

    .comment {
        background-image: url(Images/CommentInactive.PNG);
        background-size: cover;
        width: 4%;
        height: 50%;
    }

        .comment:hover {
            background-image: url(Images/CommentActive.PNG);
            background-size: cover;
            width: 4%;
            height: 50%;
        }

    .basket {
        background-image: url(Images/BasketInactive.PNG);
        background-size: cover;
        width: 4%;
        height: 50%;
    }

        .basket:hover {
            background-image: url(Images/BasketActive.PNG);
            background-size: cover;
            width: 4%;
            height: 50%;
        }

    .user {
        background-image: url(Images/UserInactive.PNG);
        background-size: cover;
        width: 4%;
        height: 50%;
    }

        .user:hover {
            background-image: url(Images/UserActive.PNG);
            background-size: cover;
            width: 4%;
            height: 50%;
        }
</style>");
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
