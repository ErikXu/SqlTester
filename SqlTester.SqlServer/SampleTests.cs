using System;
using System.Data;
using System.Linq;
using NUnit.Framework;
using SqlTester.SqlServer.Core;

namespace SqlTester.SqlServer
{
    [TestFixture]
    public class SampleTests
    {
        [SetUp]
        public void SetUp()
        {
            DatabaseContext.ConnectionString = "Your connection string";
        }

        [Test]
        public void Create()
        {
            const string col1 = "col1";
            const string col2 = "col2";
            const string col3 = "col3";
            const string sql = @"insert into sample (col1, col2, col3) values (:col1, :col2, :col3)";

            var result = sql.ExecuteNonQuery(FluentParameter.In("col1", SqlDbType.VarChar).SetSize(50).SetValue(col1),
                                             FluentParameter.In("col2", SqlDbType.VarChar).SetSize(50).SetValue(col2),
                                             FluentParameter.In("col3", SqlDbType.VarChar).SetSize(50).SetValue(col3));

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Update()
        {
            const int id = 1;
            const string col1 = "col11";
            const string col2 = "col21";
            const string col3 = "col31";

            const string sql = @"update sample 
                                 set col1 = :col1,
                                     col2 = :col2,
                                     col3 = :col3
                                     where id = :id";

            sql.ExecuteNonQuery(FluentParameter.In("col1", SqlDbType.VarChar).SetSize(50).SetValue(col1),
                                FluentParameter.In("col2", SqlDbType.VarChar).SetSize(50).SetValue(col2),
                                FluentParameter.In("col3", SqlDbType.VarChar).SetSize(50).SetValue(col3),
                                FluentParameter.In("id", SqlDbType.Int).SetValue(id));
        }

        [Test]
        public void Delete()
        {
            const int id = 2;
            const string sql = @"delete from sample where id = :id";
            sql.ExecuteNonQuery(FluentParameter.In("id", SqlDbType.Int).SetValue(id));
        }

        [Test]
        public void Query()
        {
            const string sql = @"select * from sample";

            var result = sql.ExecuteEnumerable(reader => new Sample
            {
                Id = reader.GetInt32("id"),
                Col1 = reader.GetString("col1"),
                Col2 = reader.GetString("col2"),
                Col3 = reader.GetString("col3")
            });

            Console.WriteLine(result.Count());
        }

        [Test]
        public void Find()
        {
            var id = 1;
            const string sql = @"select t* from sample where id = :id";

            var result = sql.ExecuteEnumerable(reader => new Sample
            {
                Id = reader.GetInt32("id"),
                Col1 = reader.GetString("col1"),
                Col2 = reader.GetString("col2"),
                Col3 = reader.GetString("col3")
            },
            FluentParameter.In("id", SqlDbType.Int).SetValue(id));

            Console.WriteLine("Existed? {0}", result.Any());
        }

        [Test]
        public void ExecuteStoredProcudure()
        {
            const string para1 = "para1";
            const string para2 = "para2";
            const string sql = @"Your stored procudure name";
            sql.ExecuteStoredProcedure(FluentParameter.In("para1", SqlDbType.VarChar).SetSize(50).SetValue(para1),
                                       FluentParameter.In("para2", SqlDbType.VarChar).SetSize(50).SetValue(para2));
        }

        [Test]
        public void UseTransaction()
        {
            using (var manager = ConnectionManager.GetManager())
            {
                var connection = manager.Connection;
                var trans = connection.BeginTransaction();

                try
                {
                    TransactionA();
                    TransactionB();
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }

        private void TransactionA()
        {

        }
        private void TransactionB()
        {

        }
    }

    public class Sample
    {
        public int Id { get; set; }
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
    }
}