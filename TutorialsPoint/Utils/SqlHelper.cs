using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Utils
{
    public class SqlHelper
    {
        public static string GetSqlIdsAsTempTable<T>(List<T> list, Func<T, string> selectId)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("CREATE TABLE #temp (Id INT)");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("INSERT INTO #temp (Id) VALUES ");
            foreach (var entity in list)
            {
                stringBuilder.Append("(");
                stringBuilder.Append(selectId(entity));
                stringBuilder.Append(")");
                stringBuilder.Append(",");
            }

            return stringBuilder.ToString();
        }
    }
}
