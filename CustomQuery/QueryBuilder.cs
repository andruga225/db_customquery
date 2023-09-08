using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQuery
{
    class QueryBuilder
    {
        private DBModel Model { get; }

        public QueryBuilder(DBModel model) => Model = model;

        public string BuildQuery(List<Condition> conditions, List<Tuple<string,string>> fields)
        {
            var select = "SELECT "+BuildSelectClause(fields);

            List<string> userTables = conditions.Select(c => c.TableName).Distinct().ToList();
            foreach(var i in fields)
            {
                if (userTables.Contains(i.Item1))
                    continue;
                userTables.Add(i.Item1);
            }
            var from = "FROM " + BuildFromClause(userTables);

            var where = "WHERE " + BuildWhereClause(conditions);

            if(conditions.Count==0)
                return $"{select}\n{from}";

            return $"{select}\n{from}\n{where}";
        }

        private string BuildSelectClause(List<Tuple<string,string>> fields)
        {
            var str = "";

            if (fields.Count == 0)
                return "* ";

            if (fields.Count == 1)
                return fields[0].Item1 + "." + fields[0].Item2;

            str += $"{fields[0].Item1}.{fields[0].Item2}";

            foreach(var i in fields.Skip(1))
            {
                str += $", {i.Item1}.{i.Item2}";
            }

            return str;
        }

        private string BuildWhereClause(List<Condition> conditions)
        {
            return string.Join("\nAND ",conditions.Select(c => $"{c.TableName}.{c.AttributeName} {c.Operator} {c.Value}"));
        }

        private string BuildFromClause(List<string> userTables)
        {
            if(userTables.Count==0)
            {
                return "";
            }

            if (userTables.Count == 1)
                return userTables[0];

            var pathPairs = new List<ForeignKey>();

            foreach(var table in userTables.Skip(1))
            {
                var path = GetPathForeignKeys(userTables[0], table);
                if (path is null)
                    return $"Нет связи между таблицами: {table[0]}, {table}";
                pathPairs.AddRange(path);
            }

            var fromClause = "";
            var usedTables = new HashSet<string>();
            foreach(var fc in pathPairs.Distinct())
            {
                if(fromClause=="")
                {
                    fromClause = fc.TableTo;
                    usedTables.Add(fc.TableTo);
                }

                var tableToJoin = usedTables.Contains(fc.TableFrom) ? fc.TableTo : fc.TableFrom;

                fromClause += $"\n JOIN {tableToJoin} ON {fc.TableFrom}.{fc.AttributeFrom} = {fc.TableTo}.{fc.AttributeTo}";
                
                usedTables.Add(tableToJoin);
            }

            return fromClause;
        }

        private List<ForeignKey> GetPathForeignKeys(string tableFrom, string tableTo, HashSet<string> usedTables = null)
        {
            List<ForeignKey> result = new();

            if (usedTables is null)
                usedTables = new HashSet<string>();

            var fc = Model.GetForeignKey(tableFrom, tableTo);

            if (fc != null)
            {
                result.Add(fc);
                return result;
            }

            usedTables.Add(tableFrom);

            var neighboors = Model.GetNeighboorTable(tableFrom);

            foreach(var i in neighboors)
            {
                if (usedTables.Contains(i))
                    continue;

                var path = GetPathForeignKeys(i, tableTo, usedTables);

                if (path != null)
                {
                    fc = Model.GetForeignKey(tableFrom, i);
                    path.Insert(0, fc);
                    return path;
                }
   
            }

            return null;
        }
    }
}
