﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Android.Util;
using QAiku.Model;

namespace QAiku.SharedFunctionalities
{
    public class HttpCalls
    {
        string baseurl = "http://qaiku.azurewebsites.net/api/messages/";
        HttpClient httpClient = new HttpClient();
        public async Task<List<MsgModel>> GetAllMessagesAsync()
        {
        string RestUrl = baseurl+"GetAllMessages";
            //var response = await httpClient.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));

            //var uri = new Uri(string.Format(RestUrl, "GetAllMessages"));
            List<MsgModel> Messages = null; 
            var response = await httpClient.GetAsync(RestUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Messages = JsonConvert.DeserializeObject<List<MsgModel>>(content);
            }
            return Messages;
        }

        public async Task<List<MsgModel>> GetSentMessagesAsync(string id)
        {
            string resturl = baseurl+ $"GetBySenderId?id={id}";
            var response = await httpClient.GetAsync(resturl);
            List<MsgModel> Messages = null;


            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Messages = JsonConvert.DeserializeObject<List<MsgModel>>(content);
            }
            return Messages;
        }
        public async Task<List<MsgModel>> GetReceivedMessagesAsync(string id)
        {
            string resturl = baseurl + $"GetByRecipientId?id={id}";
            var response = await httpClient.GetAsync(resturl);
            List<MsgModel> Messages = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Messages = JsonConvert.DeserializeObject<List<MsgModel>>(content);
            }
            return Messages;
        }

        public async Task<List<MsgModel>> GetThreadAsync(string id)
        {
            string resturl = baseurl + $"GetByThreadId?threadId={id}";
            var response = await httpClient.GetAsync(resturl);
            List<MsgModel> Messages = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Messages = JsonConvert.DeserializeObject<List<MsgModel>>(content);
            }
            return Messages;
        }

        public async Task<MsgModel> PutStateAsync(string id, MsgModel msg)
        {
            string resturl = baseurl + $"PutState?documentid={id}";
            var content = JsonConvert.SerializeObject(msg);
            var response = await httpClient.PutAsync(resturl, new StringContent(content, Encoding.UTF8, "application/json"));
            MsgModel Updated = msg;
            if (response.IsSuccessStatusCode)
            {
                var updated = await response.Content.ReadAsStringAsync();
                Updated = JsonConvert.DeserializeObject<MsgModel>(updated);
            }
            return Updated;
        }
    }
}