using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZE.Web.Helper
{
    public class InfoMessage
    {
        public string Message { get; set; }
        public InfoMessageType  Tip { get; set; }

        public InfoMessage() { }
        public InfoMessage(string poruka,InfoMessageType tip) {
            Message = poruka;
            Tip = tip;
        }

    }
    public enum InfoMessageType { success,info,warning,danger }
}