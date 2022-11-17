using System;
using KinUsers.Interfaces.Implementations;

namespace KinUsers.Factories
{
    public class PersistenceRetrieveEmployeeCreator
    {
        public static IPersistenceRetrieveEmployee createConnection(String region)
        {
            switch (region)
            {
                case "America":
                    return new MySQLImplementation();
                case "Asia":
                    return new PostgresImplementation();
                case "Europa":
                    return new MongoDBImplementation();
                default:
                    return new AllConnection();
            }
        }
    }
}

