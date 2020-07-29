using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;
        public CatalogService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["CatalogUrl"]}/api/catalog/";
            _client = client;

        }

        public async Task<Catalog> GetCatalogItemsAsync(int page, int size, int? organizer, int? type)
        {
            var eventItemsUri = ApiPaths.Catalog.GetAllEventItems(_baseUrl, page, size, organizer, type);
            var dataString = await _client.GetStringAsync(eventItemsUri);
            return JsonConvert.DeserializeObject<Catalog>(dataString);
        }


        public async Task<IEnumerable<SelectListItem>> GetOragizersAsync()
        {
            var organizerUri = ApiPaths.Catalog.GetAllOrganizers(_baseUrl);
            var dataString = await _client.GetStringAsync(organizerUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };
            var organizers = JArray.Parse(dataString);
            foreach (var organizer in organizers)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = organizer.Value<string>("id"),
                        Text = organizer.Value<string>("organizer")
                    });
            }
            return items;
        }
        public async Task<IEnumerable<SelectListItem>> GetTypesAsync() 
        { 
            var typeUri = ApiPaths.Catalog.GetAllTypes(_baseUrl); 
            var dataString = await _client.GetStringAsync(typeUri); 
            var items = new List<SelectListItem> 
            { 
                new SelectListItem 
                { 
                    Value = null, 
                    Text = "All", 
                    Selected = true 
                } 
            }; 
            var types = JArray.Parse(dataString); 
            foreach (var type in types) 
            { 
                items.Add(
                    new SelectListItem 
                    { 
                        Value = type.Value<string>("id"), 
                        Text = type.Value<string>("type") 
                    }); 
            } 
            return items; 
        }

    }

}      

    
