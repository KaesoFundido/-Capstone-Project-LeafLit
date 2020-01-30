using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafLit.Models
{
    public class Volumes
    {
        public string kind { get; set; }
        public int totalItems { get; set; }
        public IList<Volume> items { get; set; }
    }
    public class Volume
    {
        public string kind { get; set; }
        public string id { get; set; }
        public string etag { get; set; }
        public VolumeInfo volumeInfo { get; set; }
        public SaleInfo saleInfo { get; set; }
        public AccessInfo accessInfo { get; set; }
        public SearchInfo searchInfo { get; set; }
    }
    public class SearchInfo
    {
        public string textSnippet { get; set; }
    }

    public class AccessInfo
    {
        public string country { get; set; }
        public string viewability { get; set; }
        public Epub epub { get; set; }
        public Pdf pdf { get; set; }
        public string accessViewStatus { get; set; }
        public bool embeddable { get; set; }
        public bool publicDomain { get; set; }
        public string testToSpeechPermission { get; set; }
        public string webReaderLink { get; set; }
    }

    public class Epub
    {
        public string downloadLink { get; set; }
        public string acsTokenLink { get; set; }
        public bool isAvailable { get; set; }
    }
    public class Pdf
    {
        public string downloadLink { get; set; }
        public string acsTokenLink { get; set; }
        public bool isAvailable { get; set; }
    }

    public class SaleInfo
    {
        public string country { get; set; }
        public string saleability { get; set; }
        public bool isEbook { get; set; }
        public ListPrice listPrice { get; set; }
        public RetailPrice retailPrice { get; set; }
        public string buyLink { get; set; }
        public DateTime onSaleDate { get; set; }
    }

    public class RetailPrice
    {
        public double amount { get; set; }
        public string currencyCode { get; set; }
    }

    public class ListPrice
    {
        public double amount { get; set; }
        public string currencyCode { get; set; }
    }
    public class VolumeInfo
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public IList<string> authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
        public IList<IndustryIdentifier> industryIdentifiers { get; set; }
        public int pageCount { get; set; }
        public Dimensions dimensions { get; set; }
        public string printType { get; set; }
        public IList<string> categories { get; set; }
        public double averageRating { get; set; }
        public int ratingsCount { get; set; }
        public string contentVersion { get; set; }
        public ImageLinks imageLinks { get; set; }
        public string language { get; set; }
        public string mainCategory { get; set; }
        public string previewLink { get; set; }
        public string infoLink { get; set; }
        public string canonicalVolumeLink { get; set; }
    }

    public class ImageLinks
    {
        public string thumbnail { get; set; }
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
        public string smallThumbnail { get; set; }
        public string extraLarge { get; set; }
    }

    public class Dimensions
    {
        public string height { get; set; }
        public string width { get; set; }
        public string thickness { get; set; }
    }

    public class IndustryIdentifier
    {
        public string type { get; set; }
        public string identifier { get; set; }
    }
}
