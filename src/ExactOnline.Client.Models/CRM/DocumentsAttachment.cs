using System;

namespace ExactOnline.Client.Models.CRM
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class DocumentsAttachment
    {
        /// <summary>Filename of the attachment</summary>
        public string AttachmentFileName { get; set; }
        /// <summary>File size of the attachment</summary>
        public double AttachmentFileSize { get; set; }
        /// <summary>Url for downloading the attachment. To get the file in its original format (xml, jpg, pdf, etc.) append &lt;b&gt;&amp;Download=1&lt;/b&gt; to the url.</summary>
        public string AttachmentUrl { get; set; }

        public bool CanShowInWebView { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
    }
}
