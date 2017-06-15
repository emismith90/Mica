using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mica.Infrastructure.Extensions.IHtmlHelperExtensions
{
    public static class TableHeaderSortingExtensions
    {
        private const string UPARROW = "<i class=\"glyphicon glyphicon-triangle-top\"></i>";
        private const string DOWNARROW = "<i class=\"glyphicon glyphicon-triangle-bottom\"></i>";
        private const string DIRECTION_DESC = "desc";
        private const string DIRECTION_ASC = "asc";

        public static IHtmlContent RenderTableHeaderAnchor(this IHtmlHelper htmlHelper, 
            string linkTo, string name, string displayName)
        {
            var activeOrderBy = htmlHelper.ViewContext.HttpContext.Request.Query["orderBy"].ToString();
            var activeDirection = htmlHelper.ViewContext.HttpContext.Request.Query["orderDirection"].ToString();

            var isActiveSort = activeOrderBy.ToLower() == name.ToLower();
            var isDesc = activeDirection.ToLower() == DIRECTION_DESC;

            var arrow = isActiveSort 
                ? (isDesc ? DOWNARROW : UPARROW)
                : string.Empty;

            var direction = !isActiveSort
                ? DIRECTION_ASC
                : isDesc ? DIRECTION_ASC : DIRECTION_DESC;

            return new HtmlString(
                $"<a title=\"{displayName}\" mc-sl-to=\"{linkTo}\"" +
                    $"mc-sl-route-orderBy=\"{name}\" mc-sl-route-orderDirection=\"{direction}\">" +
                    $"{displayName} {arrow}" +
                "</a>");
        }
    }
}
