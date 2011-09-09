module BudgetbarHelper
  def budget_bar(spent, budget)
    barWidth = 0
    overBudget = false
    if spent <= budget && spent > 0
        barWidth = 100 - ((budget.to_f - spent.to_f) / budget.to_f * 100)
    else
      overBudget = true
      barWidth = ((spent.to_f - (spent.to_f - budget.to_f)) / spent.to_f) * 100
    end  
    percentComplete = barWidth > 0 ? barWidth : 0
    bottomClass = overBudget ? "bottom bg_over_budget" : "bottom bg_budget"
    bar = "<div class='bar_graph' title='#{percentComplete}%'><div class='top' style='width: #{percentComplete}%;'>
    </div><div class='bottom #{bottomClass}' style='width: 100%;'></div></div>"
    bar.html_safe
  end
end