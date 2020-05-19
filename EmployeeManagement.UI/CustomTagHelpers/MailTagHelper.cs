using EmployeeManagement.Common.ConstantsModels;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.CustomTagHelpers
{
    [HtmlTargetElement("My-Email")]
    public class MailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var mailTo = MailTo + "@" + ResultConstant.MailTagHelperSuffix;
            output.Attributes.SetAttribute("href", "MailTo:" + mailTo);
        }
    }
}
