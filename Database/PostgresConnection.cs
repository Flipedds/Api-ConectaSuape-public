using System.Data;
using Npgsql;

namespace Api.Database;

public class PostgresConnection : IDatabaseConnection
{

    public PostgresConnection()
    {
        Connection = new NpgsqlConnection(ConnectionString);
    }

    public string ConnectionString
    {
        get
        {
            return $"Host=seuHost" +
            $"Port=suaPorta;" +
            $"Database=seuBanco" +
            $"Username=seuUser" +
            $"Password=suaSenha";
        }
        set => throw new NotImplementedException();
    }

    public IDbConnection Connection {get; set;}

    public int ConnectionTimeout => Connection.ConnectionTimeout;

    public string Database => Connection.Database;

    public ConnectionState State => Connection.State;

    public IDbTransaction BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public IDbTransaction BeginTransaction(IsolationLevel il)
    {
        throw new NotImplementedException();
    }

    public void ChangeDatabase(string databaseName)
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        Connection.Close();
    }

    public IDbCommand CreateCommand()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Open()
    {
        Connection.Open();
    }
}
