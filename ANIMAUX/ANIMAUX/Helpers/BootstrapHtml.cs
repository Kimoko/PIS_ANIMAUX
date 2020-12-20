using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace ANIMAUX.Helpers
{
    public class BootstrapHtml
    {
        public static MvcHtmlString MyDropdown(string id, List<SelectListItem> selectListItems, string label)
        {
            var select = new TagBuilder("select");

            select.AddCssClass("custom-select");
            select.GenerateId(id);
            select.Attributes.Add("name", id);
            select.InnerHtml += "<option selected value='-1'>"+label+"</option>";
            foreach (var item in selectListItems)
            {
                var dropdown_menu = new TagBuilder("option");
                dropdown_menu.Attributes.Add("value", item.Value);
                dropdown_menu.SetInnerText(item.Text);
                select.InnerHtml += dropdown_menu;
            }           
            return new MvcHtmlString(select.ToString());
        }

        public static MvcHtmlString Dropdown(string id, List<SelectListItem> selectListItems, string label)
        {
            var button = new TagBuilder("button")
            {
                Attributes =
            {
                {"id", id},
                {"type", "button"},
                {"data-toggle", "dropdown"}
            }
            };

            button.AddCssClass("btn");
            button.AddCssClass("btn-secondary");
            button.AddCssClass("dropdown-toggle");

            button.SetInnerText(label);
            button.InnerHtml += " " + BuildCaret();

            var wrapper = new TagBuilder("div");
            wrapper.AddCssClass("dropdown");

            wrapper.InnerHtml += button;
            wrapper.InnerHtml += BuildDropdown(id, selectListItems);

            return new MvcHtmlString(wrapper.ToString());
        }

        private static string BuildCaret()
        {
            var caret = new TagBuilder("span");
            caret.AddCssClass("caret");

            return caret.ToString();
        }

        private static string BuildDropdown(string id, IEnumerable<SelectListItem> items)
        {
            var list = new TagBuilder("ul")
            {
                Attributes =
            {
                {"class", "dropdown-menu"},
                {"role", "menu"},
                {"aria-labelledby", id}
            }
            };

            var listItem = new TagBuilder("li");
            listItem.Attributes.Add("role", "presentation");

            items.ForEach(x => list.InnerHtml += "<li role=\"presentation\">" + BuildListRow(x) + "</li>");//получает value, которое является ссылкой можно сделать сразу сортировку || фильтрацию по нажатию

            return list.ToString();
        }

        private static string BuildListRow(SelectListItem item)
        {
            var anchor = new TagBuilder("a")
            {
                Attributes =
            {
                {"class","dropdown-item" },
                {"role", "menuitem"},
                {"tabindex", "-1"},
                {"href", item.Value}
            }
            };

            anchor.SetInnerText(item.Text);

            return anchor.ToString();
        }
    }
}