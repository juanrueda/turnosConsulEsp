using HtmlAgilityPack;

HttpClient httpClient = new HttpClient();

var response = await httpClient.GetAsync("https://www.cgeonline.com.ar/informacion/apertura-de-citas.html");
var pageContent = await response.Content.ReadAsStringAsync();

HtmlDocument pageDocument = new HtmlDocument();
pageDocument.LoadHtml(pageContent);

string? result = "";

// Seleccionar todos los nodos <tr>
foreach (HtmlNode tr in pageDocument.DocumentNode.SelectNodes("//tr"))
{
    foreach (HtmlNode td in tr.ChildNodes) //.SelectNodes("//td"))
    {
        // // Verificar si el nodo <td> contiene el texto deseado
        if (td != null && td.InnerText.Contains("Registro Civil-Nacimientos"))
            result = tr.ChildNodes[5].InnerText;
    }
}

if (result.ToLower() != "fecha por confirmar")
    Console.WriteLine(result);
else
    Console.WriteLine("Sin novedad");
