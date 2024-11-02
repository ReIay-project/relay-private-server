using System.Data.SqlClient;

namespace Relay.DBUtility;

public class DbCommon(
    string connectionString,
    string tableName)
{
    public string ConnectionString { get; } = connectionString;
    public string DatabaseName { get; } = "relay";
    public string TableName { get; } = tableName;
    public SqlConnection Connection;

    public void Connect()
    {
        var connectionString = new SqlConnectionStringBuilder(ConnectionString) { InitialCatalog = DatabaseName }.ConnectionString;
        Connection = new SqlConnection(connectionString);
    }

    public object GetData(string query)
    {
        Connection.Open();
        var command = Connection.CreateCommand();
        command.CommandText = query;
        var result = command.ExecuteReader();
        Connection.Close();
        return result;
    }

    public void UpdateData(object data)
    {
        throw new NotImplementedException();
    }
}