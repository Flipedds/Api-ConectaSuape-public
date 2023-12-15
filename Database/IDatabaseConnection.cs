using System.Data;

namespace Api.Database;

public interface IDatabaseConnection
{
    string ConnectionString {get; set;}

    IDbConnection Connection {get; set;}

    int ConnectionTimeout => Connection.ConnectionTimeout;

    string Database => Connection.Database;

    ConnectionState State => Connection.State;

    IDbTransaction BeginTransaction();

    IDbTransaction BeginTransaction(IsolationLevel il);

    void ChangeDatabase(string databaseName);

    void Close();

    IDbCommand CreateCommand();

    void Dispose();

    void Open();
}
