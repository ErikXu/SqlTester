using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlTester.SqlServer.Core
{
    public static class SqlExtension
    {
        public static object ExecuteScalar(this string sql, SqlTransaction trans, params SqlParameter[] parameters)
        {
            using (var manager = ConnectionManager.GetManager())
            {
                using (var command = manager.Connection.CreateCommand())
                {
                    command.Prepare(CommandType.Text, sql, trans, parameters);
                    return command.ExecuteScalar();
                }
            }
        }

        public static object ExecuteScalar(this string sql, params SqlParameter[] parameters)
        {
            return sql.ExecuteScalar(null, parameters);
        }

        public static int ExecuteNonQuery(this string sql, SqlTransaction trans, params SqlParameter[] parameters)
        {
            using (var manager = ConnectionManager.GetManager())
            {
                using (var command = manager.Connection.CreateCommand())
                {
                    command.Prepare(CommandType.Text, sql, trans, parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuery(this string sql, params SqlParameter[] parameters)
        {
            return sql.ExecuteNonQuery(null, parameters);
        }

        public static int ExecuteStoredProcedure(this string sql, SqlTransaction trans = null, params SqlParameter[] parameters)
        {
            using (var manager = ConnectionManager.GetManager())
            {
                using (var command = manager.Connection.CreateCommand())
                {
                    command.Prepare(CommandType.StoredProcedure, sql, trans, parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteStoredProcedure(this string sql, params SqlParameter[] parameters)
        {
            return sql.ExecuteStoredProcedure(null, parameters);
        }

        public static IEnumerable<T> ExecuteEnumerable<T>(this string sql, Func<SafeDataReader, T> convertor, params SqlParameter[] parameters)
        {
            using (var manager = ConnectionManager.GetManager())
            {
                using (var command = manager.Connection.CreateCommand())
                {
                    command.Prepare(CommandType.Text, sql, null, parameters);
                    using (var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (reader.Read())
                        {
                            yield return convertor(reader);
                        }
                    }
                }
            }
        }

        public static IEnumerable<T> ExecuteSpEnumerable<T>(this string sql, Func<SafeDataReader, T> convertor, params SqlParameter[] parameters)
        {
            using (var manager = ConnectionManager.GetManager())
            {
                using (var command = manager.Connection.CreateCommand())
                {
                    command.Prepare(CommandType.StoredProcedure, sql, null, parameters);
                    using (var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (reader.Read())
                        {
                            yield return convertor(reader);
                        }
                    }
                }
            }
        }

        public static void Prepare(this SqlCommand command, CommandType commandType, string sql, SqlTransaction trans, params SqlParameter[] parameters)
        {
            command.CommandType = commandType;
            command.CommandText = sql;

            if (trans != null)
            {
                command.Transaction = trans;
            }

            if (parameters != null && parameters.Length > 0)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }
        }
    }
}