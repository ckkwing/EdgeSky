using Models.WebChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdgeSky.Controllers
{
    public class WebChatController : Controller
    {
        private const string Token = "token_echen";

        // GET: WebChat
        [HttpGet]
        public ActionResult Index(WebChatRequestModel model)
        {
            string echoStr = Request.QueryString["echostr"];
            //WebChatRequestModel model = new WebChatRequestModel();
            //model.signature = Request.QueryString["signature"];
            //model.timestamp = Request.QueryString["timestamp"];
            //model.nonce = Request.QueryString["nonce"];
            //model.echostr = echoStr;

            if (CheckSignature(model))
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    return Content(echoStr);
                }
            }
            return null;
        }

        private bool CheckSignature(WebChatRequestModel model)
        {
            string signature, timestamp, nonce, tempStr;
            //获取请求来的参数
            signature = model.signature;
            timestamp = model.timestamp;
            nonce = model.nonce;
            //创建数组，将 Token, timestamp, nonce 三个参数加入数组
            string[] array = { Token, timestamp, nonce };
            //进行排序
            Array.Sort(array);
            //拼接为一个字符串
            tempStr = String.Join("", array);
            //对字符串进行 SHA1加密
            tempStr = CSharpLibrary.Crypto.HashUtility.GetHashedSHA1(tempStr);
            //tempStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tempStr, "SHA1").ToLower();
            //判断signature 是否正确
            //if (tempStr.Equals(signature))
            if (0 == string.Compare(tempStr, signature, true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}