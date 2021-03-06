﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;

namespace Synchronizer.Utils
{
    public static class HttpRequest
    {
        public static string GetRequestData(Stream stream)
        {
            string postString = "";

            if (stream.CanSeek)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }

            if (stream.CanRead)
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    postString = sr.ReadToEnd();
                }
            }

            return postString;

        }

        public static string Get(string url)
        {
            Stream data = null;
            WebClient wc = new WebClient();


            try
            {
                data = wc.OpenRead(url);
                if (data == null)
                {
                    LogManager.GetLogger("HTTP-REQUEST").Warn("执行Get请求时无法获取请求的内容.Url地址：" + url);
                    return "";
                }
                string result = GetRequestData(data);
                data.Close();

                return result;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("HTTP-REQUEST").Error("执行Get请求时失败，原因：\r\n" + ex.Message + "\r\nUrl地址：" + url);
                return "";
            }
        }

        public static string Post(string url, string requestBody, string dataType = "application/json")
        {
            WebClient wc = new WebClient();
            StringBuilder postBuilder = new StringBuilder();
            postBuilder.Append(requestBody);
            byte[] sendData = Encoding.UTF8.GetBytes(postBuilder.ToString());

            string baseStr = "";

            try
            {
                baseStr = Convert.ToBase64String(sendData);
                wc.Headers.Add("Content-Type", dataType);
                wc.Headers.Add("ContentLength", sendData.Length.ToString());

                byte[] recData = wc.UploadData(new Uri(url), "POST", sendData);

                string res = Encoding.UTF8.GetString(recData);

                return res;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("HTTP-REQUEST").Error("执行Get请求时失败，原因：\r\n" + ex.Message + "\r\nUrl地址：" + url);
                return "";
            }
        }


    }
}
