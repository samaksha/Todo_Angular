using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using static System.Net.WebRequestMethods;
using System.Json;
class item2
{
    public string Title { get; set; }
}
class item
{
    public int total { get; set; }
    public int total_pages { get; set; }
    public List<item2> arr;

}

var url = "https://mocki.io/v1/9c4bc02d-952c-46e9-ad4b-e79e06d12a91";

using var client = new HttpClient();
var content = await client.GetStringAsync(url);
var substr = "";
var jsonObj = JsonDocument.Parse(content);
Console.WriteLine(jsonObj.RootElement.GetProperty("total")) ;
var input = jsonObj.RootElement.GetProperty("total_pages");
var x = JObject.Parse(content);


//for(int i = 0; i<input;i++)
//{
//    var tu = url + substr + "&page" + (i+1).ToString();
//var cn = await client.GetStringAsync(tu);
//    var obj = JsonDocument.Parse(cn);


//}
