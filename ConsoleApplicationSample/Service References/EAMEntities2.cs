using System;
using System.Data.Services.Client;

namespace ConsoleApplicationSample.EAMService2
{
    public partial class EAMEntities2
    {
        public bool UseDefaultCredentials { get; set; }

        partial void OnContextCreated()
        {
            this.SendingRequest2 += new EventHandler<SendingRequest2EventArgs>(OnSendingRequest2);
        }


        private void OnSendingRequest2(object sender, SendingRequest2EventArgs e)
        {
            UseDefaultCredentials = false;
            e.RequestMessage.SetHeader("Authorization", "TCCrqi8FxqHr7ElbbYHa3NdVfRAtryvyvoukGsW/EajJ6BgwocNv74ImY7xrMM207IxwrkEH8ot8BNkqf6K7DQ==");
        }
    }
}