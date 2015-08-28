using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.IO;
using System.Net;

namespace Pikabot4
{
    public class clsWeb
    {
        public string Cookie;
        public string @ref = "";
        public string sData;
        private string sUrl;

        public clsWeb(string url)
        {
            this.sUrl = url;
        }

        public void GetCookie()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.sUrl);
                if (this.Cookie != "")
                {
                    request.Headers.Add(HttpRequestHeader.Cookie, this.Cookie);
                }
                request.KeepAlive = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = clsFunctions.generateUserAgent();
                request.Referer = "http://www.facebook.com";
                request.ContentLength = this.sData.Length;
                request.ServicePoint.ConnectionLimit = 20;
                request.AllowAutoRedirect = true;
                request.Timeout = 30000;
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(this.sData);
                writer.Flush();
                writer.Close();
                this.Cookie = "";
                request.CookieContainer = new CookieContainer();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                if (response.Cookies.Count > 0)
                {
                    this.Cookie = "";
                    int num2 = response.Cookies.Count - 1;
                    for (int i = 0; i <= num2; i++)
                    {
                        this.Cookie = this.Cookie + response.Cookies[i].ToString() + ";";
                    }
                    this.Cookie = Strings.Mid(this.Cookie, 1, Strings.Len(this.Cookie) - 1);
                }
                else
                {
                    this.Cookie = "";
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        public void GetHTTPCookie()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.sUrl);
                if (this.Cookie != "")
                {
                    request.Headers.Add(HttpRequestHeader.Cookie, this.Cookie);
                }
                request.KeepAlive = true;
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1) Gecko/20090624 Firefox/3.5 (.NET CLR 3.5.30729)";
                request.Referer = "http://www.facebook.com";
                request.ServicePoint.ConnectionLimit = 20;
                request.AllowAutoRedirect = true;
                request.Timeout = 30000;
                this.Cookie = "";
                request.CookieContainer = new CookieContainer();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                if (response.Cookies.Count > 0)
                {
                    this.Cookie = "";
                    int num2 = response.Cookies.Count - 1;
                    for (int i = 0; i <= num2; i++)
                    {
                        this.Cookie = this.Cookie + response.Cookies[i].ToString() + ";";
                    }
                    this.Cookie = Strings.Mid(this.Cookie, 1, Strings.Len(this.Cookie) - 1);
                }
                else
                {
                    this.Cookie = "";
                }
                WebResponse response2 = request.GetResponse();
                string str = string.Empty;
                str = new StreamReader(response2.GetResponseStream()).ReadToEnd();
                this.sData = str;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        public void GetUrl()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.sUrl);
                request.KeepAlive = false;
                request.Referer = this.@ref;
                if (clsFunctions.generateUserAgent() == "")
                {
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.6) Gecko/20091201 Firefox/3.5.6";
                }
                else
                {
                    request.UserAgent = clsFunctions.generateUserAgent();
                }
                if (this.Cookie != "")
                {
                    request.Headers.Add(HttpRequestHeader.Cookie, this.Cookie);
                }
                request.Timeout = 0x7530;
                string str = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                this.sData = str;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                this.sData = "";
                ProjectData.ClearProjectError();
            }
        }

        public void PostUrl()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.sUrl);
                if (this.Cookie != "")
                {
                    request.Headers.Add(HttpRequestHeader.Cookie, this.Cookie);
                }
                request.KeepAlive = false;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                if (clsFunctions.generateUserAgent() == "")
                {
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.6) Gecko/20091201 Firefox/3.5.6";
                }
                else
                {
                    request.UserAgent = clsFunctions.generateUserAgent();
                }
                request.ContentLength = this.sData.Length;
                request.ServicePoint.ConnectionLimit = 20;
                request.AllowAutoRedirect = true;
                request.Timeout = 0x7530;
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(this.sData);
                writer.Flush();
                writer.Close();
                WebResponse response = request.GetResponse();
                string str = string.Empty;
                str = new StreamReader(response.GetResponseStream()).ReadToEnd();
                this.sData = str;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                this.sData = "";
                ProjectData.ClearProjectError();
            }
        }
    }
}
