using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public static class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}/EventTypes";
            }

            public static string GetAllOrganizers(string baseUri)
            {
                return $"{baseUri}/EventOrganizers";
            }

            public static string GetAllEventItems(string baseUri, int page, int take, int? type, int? organizer)
            {
                var filterQs = string.Empty;

                if (type.HasValue || organizer.HasValue)
                {
                    var typeQs = (type.HasValue) ? type.Value.ToString() : " ";
                    var organizerQs = (organizer.HasValue) ? organizer.Value.ToString() : " ";
                    filterQs = $"/type/{typeQs}/organizer/{organizerQs}";
                }

                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }
        }

        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }
    }
}
