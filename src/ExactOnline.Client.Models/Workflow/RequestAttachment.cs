using System;

namespace ExactOnline.Client.Models.Workflow
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class RequestAttachment
    {
        /// <summary>The division</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>To get the file in its original format (xml, jpg, pdf, etc.) append &lt;b&gt;&amp;Download=1&lt;/b&gt; to the url.</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string DownloadUrl { get; set; }
        /// <summary>Filename of the attachment</summary>
        public string FileName { get; set; }
        /// <summary>File size of the attachment</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double FileSize { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>The request this attachment is linked to</summary>
        public Guid? Request { get; set; }
    }
}
