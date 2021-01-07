using System.Collections.Generic;

namespace LuxuryHomeMarketing
{
    class States : List<string>
    {

        private string[] initStates = {

            "AK", "AL", "AR", "AS", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", 
            //"GA", "GU", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA",
            //"MD", "ME", "MI", "MN", "MO", "MP", "MS", "MT", "NC", "ND", "NE",
            //"NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "PR", "RI",
            //"SC", "SD", "TN", "TX", "UM", "UT", "VA", "VI", "VT", "WA", "WI",
            "WV", "WY", 
            //"AB", "BC", "MB", "NB", "NF", "NS", "NT", "NU", "ON", "PE", "QC",
            "SK", "YT" };

        public States()
        {
            foreach (string state in initStates)
            {
                Add(state);
            }
        }

    }

}