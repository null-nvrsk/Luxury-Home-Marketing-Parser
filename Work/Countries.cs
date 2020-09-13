using System.Collections.Generic;

namespace LuxuryHomeMarketing
{
    class Countries : List<string>
    {

        private string[] initCountries = {
            "US/CA", "AF", "AI" 
            // , "AR", "AT", "BS", "BE", "BZ", "BO", "BR",
            //"KY", "CL", "CN", "CR", "CZ", "DO", "EC", "EE", "FR", "DE", "GU",
            //"IN", "ID", "IE", "IL", "IT", "JM", "JP", "KP", "KR", "LU", "MX",
            //"AN", "NZ", "NI", "OM", "PA", "PY", "PE", "PH", "PT", "PR", "RO",
            // "ZA", "ES", "LK", "CH", "TR", "AE", "GB", "UM", "UY", "VG", "VI"
        };

        public Countries()
        {
            foreach (string country in initCountries)
            {
                Add(country);
            }
        }

    }
}