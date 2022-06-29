using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeJiraDataLibrary.Processors
{
    public class GetUserId
    {
        public static int GetUserIdentity(string authUser)
        {
            //TODO: returns fake id, because authentification wouldn't pass other user at this point.
            var userId = DataAccess.SQLDataAccess.LoadData<int>($@"select t.id from dbo.Users t where t.EmailAddress = '{authUser}'").ToList();
            return 1;
        }

    }
}