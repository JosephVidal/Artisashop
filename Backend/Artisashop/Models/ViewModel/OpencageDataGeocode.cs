using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Artisashop.Models.ViewModel
{
    public class OpencageDataGeocode
    {
        public class RateInfo
        {
            [JsonProperty("limit")]
            [JsonPropertyName("limit")]
            public int Limit { get; set; }

            [JsonProperty("remaining")]
            [JsonPropertyName("remaining")]
            public int Remaining { get; set; }

            [JsonProperty("reset")]
            [JsonPropertyName("reset")]
            public int Reset { get; set; }
        }

        public class LicenseInfo
        {

            [JsonProperty("name")]
            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonProperty("url")]
            [JsonPropertyName("url")]
            public string? URL { get; set; }
        }

        public class SocialInfo
        {

            [JsonProperty("blog")]
            [JsonPropertyName("blog")]
            public string? Blog { get; set; }

            [JsonProperty("twitter")]
            [JsonPropertyName("twitter")]
            public string? Twitter { get; set; }
        }

        public class CreatedTimestampInfo
        {

            [JsonProperty("created_http")]
            [JsonPropertyName("created_http")]
            public string? CreatedHTTP { get; set; }

            [JsonProperty("created_unix")]
            [JsonPropertyName("created_unix")]
            public int CreatedUnix { get; set; }
        }

        public class ResultData
        {

            public class BoundInfo
            {

                [JsonProperty("northeast")]
                [JsonPropertyName("northeast")]
                public GPSCoord? Northeast { get; set; }

                [JsonProperty("southwest")]
                [JsonPropertyName("southwest")]
                public GPSCoord? Southwest { get; set; }
            }

            public class ComponentsInfo
            {

                [JsonProperty("ISO_3166-1_alpha-2")]
                [JsonPropertyName("ISO_3166-1_alpha-2")]
                public string? ISO3166_1Alpha2 { get; set; }

                [JsonProperty("ISO_3166-1_alpha-3")]
                [JsonPropertyName("ISO_3166-1_alpha-3")]
                public string? ISO3166_1Alpha3 { get; set; }

                [JsonProperty("ISO_3166-2")]
                [JsonPropertyName("ISO_3166-2")]
                public List<string>? ISO3166_2 { get; set; }

                [JsonProperty("_category")]
                [JsonPropertyName("_category")]
                public string? Category { get; set; }

                [JsonProperty("_type")]
                [JsonPropertyName("_type")]
                public string? Type { get; set; }

                [JsonProperty("city")]
                [JsonPropertyName("city")]
                public string? City { get; set; }

                [JsonProperty("continent")]
                [JsonPropertyName("continent")]
                public string? Continent { get; set; }

                [JsonProperty("country")]
                [JsonPropertyName("country")]
                public string? Country { get; set; }

                [JsonProperty("country_code")]
                [JsonPropertyName("country_code")]
                public string? CountryCode { get; set; }

                [JsonProperty("postcode")]
                [JsonPropertyName("postcode")]
                public string? Postcode { get; set; }

                [JsonProperty("restaurant")]
                [JsonPropertyName("restaurant")]
                public string? Restaurant { get; set; }

                [JsonProperty("road")]
                [JsonPropertyName("road")]
                public string? Road { get; set; }

                [JsonProperty("state")]
                [JsonPropertyName("state")]
                public string? State { get; set; }

                [JsonProperty("suburb")]
                [JsonPropertyName("suburb")]
                public string? Suburb { get; set; }
            }

            public class AnnotationList
            {
                public class DMSAnnotation
                {

                    [JsonProperty("lat")]
                    [JsonPropertyName("lat")]
                    public string? Latitude { get; set; }

                    [JsonProperty("lng")]
                    [JsonPropertyName("lng")]
                    public string? Longitude { get; set; }
                }

                public class MercatorAnnotation
                {

                    [JsonProperty("x")]
                    [JsonPropertyName("x")]
                    public double X { get; set; }

                    [JsonProperty("y")]
                    [JsonPropertyName("y")]
                    public double Y { get; set; }
                }

                public class OSMAnnotation
                {

                    [JsonProperty("edit_url")]
                    [JsonPropertyName("edit_url")]
                    public string? EditURL { get; set; }

                    [JsonProperty("note_url")]
                    [JsonPropertyName("note_url")]
                    public string? NoteURL { get; set; }

                    [JsonProperty("url")]
                    [JsonPropertyName("url")]
                    public string? URL { get; set; }
                }

                public class CurrencyInfo
                {

                    [JsonProperty("alternate_symbols")]
                    [JsonPropertyName("alternate_symbols")]
                    public List<string>? AlternateSymbols { get; set; }

                    [JsonProperty("decimal_mark")]
                    [JsonPropertyName("decimal_mark")]
                    public string? DecimalMark { get; set; }

                    [JsonProperty("disambiguate_symbol")]
                    [JsonPropertyName("disambiguate_symbol")]
                    public string? DisambiguateSymbol { get; set; }

                    [JsonProperty("format")]
                    [JsonPropertyName("format")]
                    public string? Format { get; set; }

                    [JsonProperty("html_entity")]
                    [JsonPropertyName("html_entity")]
                    public string? HTMLEntity { get; set; }

                    [JsonProperty("iso_code")]
                    [JsonPropertyName("iso_code")]
                    public string? ISOCode { get; set; }

                    [JsonProperty("iso_numeric")]
                    [JsonPropertyName("iso_numeric")]
                    public string? ISONumeric { get; set; }

                    [JsonProperty("name")]
                    [JsonPropertyName("name")]
                    public string? Name { get; set; }

                    [JsonProperty("smallest_denomination")]
                    [JsonPropertyName("smallest_denomination")]
                    public int SmallestDenomination { get; set; }

                    [JsonProperty("subunit")]
                    [JsonPropertyName("subunit")]
                    public string? Subunit { get; set; }

                    [JsonProperty("subunit_to_unit")]
                    [JsonPropertyName("subunit_to_unit")]
                    public int SubunitToUnit { get; set; }

                    [JsonProperty("symbol")]
                    [JsonPropertyName("symbol")]
                    public string? Symbol { get; set; }

                    [JsonProperty("symbol_first")]
                    [JsonPropertyName("symbol_first")]
                    public int SymbolFirst { get; set; }

                    [JsonProperty("thousands_separator")]
                    [JsonPropertyName("thousands_separator")]
                    public string? ThousandsSeparator { get; set; }
                }

                public class RoadInfo
                {

                    [JsonProperty("drive_on")]
                    [JsonPropertyName("drive_on")]
                    public string? DriveOn { get; set; }

                    [JsonProperty("road")]
                    [JsonPropertyName("road")]
                    public string? Road { get; set; }

                    [JsonProperty("speed_in")]
                    [JsonPropertyName("speed_in")]
                    public string? SpeedIn { get; set; }
                }

                public class SunInfo
                {
                    public class SunInfoData
                    {
                        [JsonProperty("apparent")]
                        [JsonPropertyName("apparent")]
                        public int Apparent { get; set; }

                        [JsonProperty("astronomical")]
                        [JsonPropertyName("astronomical")]
                        public int Astronomical { get; set; }

                        [JsonProperty("civil")]
                        [JsonPropertyName("civil")]
                        public int Civil { get; set; }

                        [JsonProperty("nautical")]
                        [JsonPropertyName("nautical")]
                        public int Nautical { get; set; }
                    }

                    [JsonProperty("rise")]
                    [JsonPropertyName("rise")]
                    public SunInfoData? Rise { get; set; }

                    [JsonProperty("set")]
                    [JsonPropertyName("set")]
                    public SunInfoData? Set { get; set; }
                }

                public class TimezoneInfo
                {

                    [JsonProperty("name")]
                    [JsonPropertyName("name")]
                    public string? Name { get; set; }

                    [JsonProperty("now_in_dst")]
                    [JsonPropertyName("now_in_dst")]
                    public int NowInDST { get; set; }

                    [JsonProperty("offset_sec")]
                    [JsonPropertyName("offset_sec")]
                    public int OffsetSec { get; set; }

                    [JsonProperty("offset_string")]
                    [JsonPropertyName("offset_string")]
                    public string? OffsetString { get; set; }

                    [JsonProperty("short_name")]
                    [JsonPropertyName("short_name")]
                    public string? ShortName { get; set; }
                }

                public class What3WordsData
                {

                    [JsonProperty("words")]
                    [JsonPropertyName("words")]
                    public string? Words { get; set; }
                }

                [JsonProperty("DMS")]
                [JsonPropertyName("DMS")]
                public DMSAnnotation? DMS { get; set; }

                [JsonProperty("MGRS")]
                [JsonPropertyName("MGRS")]
                public string? MGRS { get; set; }

                [JsonProperty("Maidenhead")]
                [JsonPropertyName("Maidenhead")]
                public string? Maidenhead { get; set; }

                [JsonProperty("Mercator")]
                [JsonPropertyName("Mercator")]
                public MercatorAnnotation? Mercator { get; set; }

                [JsonProperty("OSM")]
                [JsonPropertyName("OSM")]
                public OSMAnnotation? OSM { get; set; }

                [JsonProperty("callingcode")]
                [JsonPropertyName("callingcode")]
                public int Callingcode { get; set; }

                [JsonProperty("currency")]
                [JsonPropertyName("currency")]
                public CurrencyInfo? Currency { get; set; }

                [JsonProperty("flag")]
                [JsonPropertyName("flag")]
                public string? Flag { get; set; }

                [JsonProperty("geohash")]
                [JsonPropertyName("geohash")]
                public string? Geohash { get; set; }

                [JsonProperty("qibla")]
                [JsonPropertyName("qibla")]
                public double Qibla { get; set; }

                [JsonProperty("roadinfo")]
                [JsonPropertyName("roadinfo")]
                public RoadInfo? Roadinfo { get; set; }

                [JsonProperty("sun")]
                [JsonPropertyName("sun")]
                public SunInfo? Sun { get; set; }

                [JsonProperty("timezone")]
                [JsonPropertyName("timezone")]
                public TimezoneInfo? Timezone { get; set; }

                [JsonProperty("what3words")]
                [JsonPropertyName("what3words")]
                public What3WordsData? What3Words { get; set; }
            }

            [JsonProperty("components")]
            [JsonPropertyName("components")]
            public ComponentsInfo? Components { get; set; }

            [JsonProperty("bounds")]
            [JsonPropertyName("bounds")]
            public BoundInfo? Bounds { get; set; }

            [JsonProperty("geometry")]
            [JsonPropertyName("geometry")]
            public GPSCoord? Geometry { get; set; }

            [JsonProperty("formatted")]
            [JsonPropertyName("formatted")]
            public string? Formatted { get; set; }

            [JsonProperty("confidence")]
            [JsonPropertyName("confidence")]
            public int Confidence { get; set; }
        }

        [JsonProperty("documentation")]
        [JsonPropertyName("documentation")]
        public string? Doc { get; set; }

        [JsonProperty("licenses")]
        [JsonPropertyName("licenses")]
        public List<LicenseInfo>? Licenses { get; set; }

        [JsonProperty("rate")]
        [JsonPropertyName("rate")]
        public RateInfo? Rate { get; set; }

        [JsonProperty("results")]
        [JsonPropertyName("results")]
        public List<ResultData>? Results { get; set; }

        [JsonProperty("total_results")]
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("stay_informed")]
        [JsonPropertyName("stay_informed")]
        public SocialInfo? SocialLink { get; set; }

        [JsonProperty("thanks")]
        [JsonPropertyName("thanks")]
        public string? Thanks { get; set; }

        [JsonProperty("timestamp")]
        [JsonPropertyName("timestamp")]
        public CreatedTimestampInfo? CreatedTimestamp { get; set; }
    }
}
