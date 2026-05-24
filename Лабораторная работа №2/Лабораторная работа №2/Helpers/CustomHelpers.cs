using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Лабораторная_работа__2.Helpers
{
    public static class CustomHelpers
    {
        public static IHtmlContent ClientCard(this IHtmlHelper html, string fullName, string phone, string email, bool isProcessed)
        {
            string statusClass = isProcessed ? "processed" : "notprocessed";
            string statusText = isProcessed ? "Обработан" : "Не обработан";

            string htmlString = $@"
                <div class='client-card {statusClass}'>
                    <h4>{fullName}</h4>
                    <p>Телефон: {phone}</p>
                    <p>Email: {email}</p>
                    <p>Статус: {statusText}</p>
                </div>";
            return new HtmlString(htmlString);
        }
    }
}