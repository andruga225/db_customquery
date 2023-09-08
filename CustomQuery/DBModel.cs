using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQuery
{
    class DBModel
    {
        private string connStr;

        public List<Attribute> Attributes { get; }

        public List<ForeignKey> ForeignKeys { get; }

        public List<string> Tables => Attributes.Select(attr => attr.TableName).Distinct().ToList();

        public DBModel(string connStr)
        {
            Attributes = new List<Attribute>();
            LoadAttributes(connStr);

            ForeignKeys = new List<ForeignKey>();
            LoadForeignKeys(connStr);
        }

        private void LoadForeignKeys(string connStr)
        {
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand()
                {
                    Connection = conn,
                    CommandText = @"SELECT
                                        tc.table_name as original_table,
                                        kcu.column_name as original_attribute,
                                        ccu.table_name AS foreign_table,
                                        ccu.column_name AS foreign_attribute
                                    FROM
                                        information_schema.table_constraints AS tc
                                        JOIN information_schema.key_column_usage AS kcu
                                          ON tc.constraint_name = kcu.constraint_name
                                          AND tc.table_schema = kcu.table_schema
                                        JOIN information_schema.constraint_column_usage AS ccu
                                          ON ccu.constraint_name = tc.constraint_name
                                          AND ccu.table_schema = tc.table_schema
                                    WHERE tc.constraint_type = 'FOREIGN KEY';"
                })
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ForeignKeys.Add(new ForeignKey
                        {
                            TableFrom = (string)reader["foreign_table"],
                            AttributeFrom=(string)reader["foreign_attribute"],
                            TableTo=(string)reader["original_table"],
                            AttributeTo=(string)reader["original_attribute"]
                        });
                    }
                }
            }
        }

        public List<string> GetNeighboorTable(string tableFrom)
        {
            return ForeignKeys.Where(fc => fc.TableTo == tableFrom).Select(fc => fc.TableFrom).Union(
                ForeignKeys.Where(fc => fc.TableFrom == tableFrom).Select(fc => fc.TableTo)).ToList();
        }

        public ForeignKey GetForeignKey(string tableFrom, string tableTo)
        {
            return ForeignKeys.FirstOrDefault(fc => fc.TableFrom == tableFrom && fc.TableTo == tableTo ||
                                        fc.TableFrom == tableTo && fc.TableTo == tableFrom);
        }

        public List<Attribute> GetTableAttributes(string selectedTable)
        {
            return Attributes.Where(attr => attr.TableName == selectedTable).ToList();
        }

        private void LoadAttributes(string connStr)
        {
            using(var conn=new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand()
                {
                    Connection = conn,
                    CommandText = @"SELECT
                                        pg_class.relname as table_name,
                                        pg_attribute.attname AS attribute_name,
                                        typcategory as type_category
                                    FROM
                                        pg_catalog.pg_attribute
                                    INNER JOIN
                                        pg_catalog.pg_class ON pg_class.oid = pg_attribute.attrelid
                                    INNER JOIN
                                        pg_catalog.pg_namespace ON pg_namespace.oid = pg_class.relnamespace
                                    INNER JOIN
                                        pg_catalog.pg_type on pg_attribute.atttypid = pg_type.oid
                                    WHERE
                                        pg_attribute.attnum > 0
                                        AND NOT pg_attribute.attisdropped
                                        AND pg_namespace.nspname = 'public'
                                        AND pg_class.relkind='r'
                                    ORDER BY
                                        table_name ASC,
                                        attnum ASC;"
                })
                {
                    var reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        var table_name = (string)reader["table_name"];
                        var attribute_name = (string)reader["attribute_name"];
                        var type_name = (char)reader["type_category"];

                        Attributes.Add(new Attribute()
                        {
                            Name = attribute_name,
                            TableName = table_name,
                            Type = type_name
                        }); 
                    }
                }
            }
        }
    }
}
