using HtmlAgilityPack;

List<String> selectedRow = new List<string>();

HttpClient httpClient = new HttpClient();

var response = await httpClient.GetAsync("https://www.cgeonline.com.ar/informacion/apertura-de-citas.html");
var pageContent = await response.Content.ReadAsStringAsync();

HtmlDocument pageDocument = new HtmlDocument();
pageDocument.LoadHtml(pageContent);

HtmlNode? trSelected = null;
string? result = "Sin cambios";

// Seleccionar tabla
foreach (HtmlNode table in pageDocument.DocumentNode.SelectNodes("//table"))
{
    // Seleccionar todos los nodos <tr>
    foreach (HtmlNode tr in table.SelectNodes("//tr"))
    {
        foreach (HtmlNode td in tr.SelectNodes("//td"))
        {
            // Verificar si el nodo <td> contiene el texto deseado
            if (td != null && td.InnerText.Contains("Registro Civil-Nacimientos"))
            {
                var cont = 1;
            }
        }
    }
}


// if (trSelected != null)
// {
//     foreach (HtmlNode td in trSelected.SelectNodes("//td"))
//     {
//         Console.WriteLine(td.InnerText);
//         // cont++;
//         // if (cont == 3 && td != null && td.InnerText != "fecha por confirmar")
//         // {
//         //     result = td.InnerText;
//         // }
//     }
// }

//Console.WriteLine(result);
