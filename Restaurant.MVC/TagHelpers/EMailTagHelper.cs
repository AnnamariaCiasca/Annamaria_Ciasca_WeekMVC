using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC.TagHelpers
{
    public class EMailTagHelper : TagHelper
    {
        public string ToUser { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent("Send an e-mail!");
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Attributes.SetAttribute("href", $"mailto:{ToUser}");
        }
    }
}