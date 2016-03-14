using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlTester.SqlServer.Core
{
    public static class FluentParameter
    {
        public static SqlParameter In(string name, SqlDbType dbType)
        {
            var parameter = new SqlParameter
            {
                ParameterName = name.StartsWith("@") ? name : "@" + name,
                SqlDbType = dbType,
                Direction = ParameterDirection.Input
            };

            return parameter;
        }

        public static SqlParameter SetValue(this SqlParameter parameter, object value)
        {
            parameter.Value = (value ?? DBNull.Value);
            return parameter;
        }

        public static SqlParameter SetSize(this SqlParameter parameter, int size)
        {
            if (size > 0)
            {
                parameter.Size = size;
            }

            return parameter;
        }
    }
}