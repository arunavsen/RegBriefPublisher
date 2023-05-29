namespace RegBriefPublisher.Models
{
    public class Brief
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public DateTime PubDate { get; set; }
        public List<BriefCountryMap> briefCountryMaps { get; set; } = new List<BriefCountryMap>();

    }

    public class BriefCountryMap
    {
        public int Id { get; set; }
        public int BriefId { get; set; }
        public Brief Brief { get; set; }
        //public int CoutryId { get; set; }
        //public Country Country { get; set; }
        public string CountryName { get; set; }
        public List<WTABrief> wTABriefs { get; set; } = new List<WTABrief>();
        public List<TPABrief> tPABriefs { get; set; } = new List<TPABrief>();
        public List<TAXBrief> tAXBriefs { get; set; } = new List<TAXBrief>();
    }

    public class WTABrief
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortStory { get; set; }
        public string LongStory { get; set; }
        public BriefCountryMap BriefCountryMap { get; set; }
    }

    //public class Country 
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Code { get; set; }
    //}

    public class TPABrief
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortStory { get; set; }
        public string LongStory { get; set; }
        public BriefCountryMap BriefCountryMap { get; set; }

    }

    public class TAXBrief
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortStory { get; set; }
        public string LongStory { get; set; }
    }
}
