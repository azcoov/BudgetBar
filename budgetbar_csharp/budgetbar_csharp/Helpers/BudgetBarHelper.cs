using System;
using System.Web.Mvc;

namespace budgetbar_csharp.Helpers
{
    public static class BudgetBarHelper
    {
        public static MvcHtmlString BudgetBar(this HtmlHelper helper, decimal spent, decimal budget)
        {
            //todo: move this into a helper
            decimal? barWidth = 0;
            var overBudget = false;
            if (spent <= budget && spent > 0)
            {
                barWidth = 100 - ((budget - spent) / budget * 100);
            }
            else
            {
                overBudget = true;
                barWidth = ((spent - (spent - budget)) / spent) * 100;
            }
            var percentComplete = barWidth > 0 ? ((Decimal)barWidth).ToString("##.##") + "%" : "0%";
            var bottomClass = overBudget ? "bottom bg_over_budget" : "bottom bg_budget";

            var container = new TagBuilder("div");
            container.Attributes.Add("class", "bar_graph");
            container.Attributes.Add("title", percentComplete.ToString());

            var top = new TagBuilder("div");
            top.Attributes.Add("class", "top");
            top.Attributes.Add("style", String.Format("width: {0}", percentComplete));

            var bottom = new TagBuilder("div");
            bottom.Attributes.Add("class", bottomClass);
            bottom.Attributes.Add("style", "width: 100%");

            container.InnerHtml = top.ToString();
            container.InnerHtml += bottom.ToString();

            return MvcHtmlString.Create(container.ToString());

        }
    }
}