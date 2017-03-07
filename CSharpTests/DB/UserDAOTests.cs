using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CSharp.DB.Tests
{
    [TestFixture]
    public class UserDAOTests
    {
        UserDAO dao;

        [SetUp]
        protected void setUp()
        {
            dao = new UserDAO();
        }

        [TearDown]
        protected void tearDown()
        {
            // Reset database
            clearDataBase();
        }

        [Test]
        public void testListUsers()
        {
            List<User> lista = dao.listAll();
            User user = lista[0];
            Assert.AreEqual(1, lista.Count);
            Assert.AreEqual("henbreda", user.login);
            Assert.AreEqual("Henrique Breda", user.name);
            Assert.AreEqual("henrique.breda@email.com", user.email);
        }

        [Test]
        public void testAddUser()
        {
            User user = new User
            {
                login = "none",
                name = "None User",
                email = "none.user@email.com"
            };
            dao.addUser(user);
            Assert.AreEqual(2, dao.listAll().Count);
        }

        private void clearDataBase()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = Settings.Default.CONNECTION_URL;
            connectionString.Port = uint.Parse(Settings.Default.CONNECTION_PORT);
            connectionString.Database = Settings.Default.DATABASE;
            connectionString.UserID = Settings.Default.USERNAME;
            connectionString.Password = Settings.Default.PASSWORD;

            NDbUnit.Core.INDbUnitTest mySqlDatabase = new NDbUnit.Core.MySqlClient.MySqlDbUnitTest(connectionString.ToString());

            mySqlDatabase.ReadXmlSchema(AppDomain.CurrentDomain.BaseDirectory + @"XML\user.xsd");
            mySqlDatabase.ReadXml(AppDomain.CurrentDomain.BaseDirectory + @"XML\user.xml");

            mySqlDatabase.PerformDbOperation(NDbUnit.Core.DbOperationFlag.CleanInsertIdentity);
        }
    }
}