using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WebChat
{
    public class WebChatRequestModel
    {
        private readonly string format = @"WebChatRequestModel signature:{0}, timestamp{1}, nonce{2}, echostr{3}";
        public string signature { get; set; }
        public string timestamp { get; set; }
        public string nonce { get; set; }
        public string echostr { get; set; }

        public override string ToString()
        {
            return string.Format(format, signature, timestamp, nonce, echostr);
        }
    }
}
