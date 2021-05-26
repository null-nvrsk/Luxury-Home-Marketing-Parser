using System.Collections.Generic;
using System.Collections.ObjectModel;
using Parser_WPF.Models;

namespace Parser_WPF.Interfaces
{
    public interface ISearchPage
    {
        string GetPageWithCountryResults(Country country);
        string ParsePageWithCountry(Country country);

        string GetPageWithStateResults(State state);
        string ParsePageWithState(State state);

        string GetPageWithMembershipResults(MemberLevel memberLevel);
        string ParsePageMembership(MemberLevel memberLevel);

        Collection<Member> ParsePage(string response);

        bool ParseToManyResultError(string response);

    }
}