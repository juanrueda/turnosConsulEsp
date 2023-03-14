using HtmlAgilityPack;

HttpClient httpClient = new HttpClient();

var response = await httpClient.GetAsync("https://www.cgeonline.com.ar/informacion/apertura-de-citas.html");
var pageContent = await response.Content.ReadAsStringAsync();

HtmlDocument pageDocument = new HtmlDocument();
pageDocument.LoadHtml(pageContent);

string? result = "Sin cambios";
//List<HtmlNode> selectedTr = new List<HtmlNode>();

HtmlNode selectedTr = null;

// Seleccionar todos los nodos <tr>
foreach (HtmlNode tr in pageDocument.DocumentNode.SelectNodes("//tr"))
{
    foreach (HtmlNode td in tr.SelectNodes("//td"))
    {
        // Verificar si el nodo <td> contiene el texto deseado
        if (td != null && td.InnerText.Contains("Registro Civil-Nacimientos"))
        { 
            selectedTr = tr;
        }
    }
}

foreach (HtmlNode td in selectedTr.SelectNodes("//td"))
{
    Console.WriteLine(td.InnerText);
}

//Console.WriteLine(result);
