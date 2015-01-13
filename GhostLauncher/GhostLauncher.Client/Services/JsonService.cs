using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;
using GhostLauncher.Entities;
using GhostLauncher.Entities.JsonResponse;

namespace GhostLauncher.Client.Services
{
    public class JsonService
    {
        private const string BaseUrl = "http://localhost:59555/api/";
        public static readonly string ALL_MINECRAFT_VERSIONS = "MinecraftVersion";

        private static string CreateUrl(string direction)
        {
            return BaseUrl + direction;
        }

        public static List<T> RequestList<T>(string requestUrl, bool buildUrlFromBase = true)
        {
            if (buildUrlFromBase)
            {
                requestUrl = CreateUrl(requestUrl);
            }

            try
            {
                var request = WebRequest.Create(requestUrl) as HttpWebRequest;
                if (request != null)
                {
                    var response = request.GetResponse() as HttpWebResponse;
                    if (response != null && response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                    }

                    var jsonSerializer = new DataContractJsonSerializer(typeof(ResponseList<T>));
                    var objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    var jsonResponse = objResponse as ResponseList<T>;
                    if (jsonResponse != null)
                    {
                        return jsonResponse.Result;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public static T RequestItem<T>(string requestUrl, int id, bool buildUrlFromBase = true)
        {
            if (buildUrlFromBase)
            {
                requestUrl = CreateUrl(requestUrl);
            }

            try
            {
                var request = WebRequest.Create(requestUrl) as HttpWebRequest;
                if (request != null)
                {
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response != null && response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                        }

                        var jsonSerializer = new DataContractJsonSerializer(typeof(ResponseItem<T>));
                        var objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        var jsonResponse = objResponse as ResponseItem<T>;
                        if (jsonResponse != null)
                        {
                            return jsonResponse.Result;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Activator.CreateInstance<T>();
        }
    }
}
