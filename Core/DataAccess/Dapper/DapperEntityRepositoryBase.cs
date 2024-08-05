using Core;
using Core.DataAccess;
using Core.Entities;
using Dapper;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

public class DapperEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
{
    private SqlConnection _connection;
    private string _tableName;

    public DapperEntityRepositoryBase()
    {
        _connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true;");
        _tableName = GetTableName(typeof(TEntity));
    }

    public void Add(TEntity entity)
    {
        var values = GetColumnValues(entity);
        var columns = values.Replace("@", string.Empty);
        var parameters = GetParameters(entity);

        var query = $"insert into {_tableName} ({columns}) values ({values})";
        _connection.Execute(query, parameters);
    }

    public void Delete(int id)
    {
        var primaryKey = GetPrimaryKeyName();
        _connection.Query($"delete from {_tableName} where {primaryKey} = {id}");
    }

    public TEntity GetById(int id)
    {
        var primaryKey = GetPrimaryKeyName();
        return _connection.Query<TEntity>($"select * from {_tableName} where {primaryKey} = {id}").Single();
    }

    public List<TEntity> GetAll()
    {
        return _connection.Query<TEntity>($"select * from {_tableName}").ToList();
    }

    public void Update(TEntity entity)
    {
        var values = GetColumnValues(entity);
        var columns = values.Replace("@", string.Empty);
        var parameters = GetParameters(entity);
        var pairs = KeyValuePair(columns, values);
        var primaryKey = GetPrimaryKeyName();

        var query = $"update {_tableName} set {pairs} where {primaryKey} = @{primaryKey}";
        _connection.Execute(query, parameters);
    }

    private static string GetColumnValues(TEntity entity)
    {
        var propertyNames = typeof(TEntity).GetProperties()
            .Where(p => !Attribute.IsDefined(p, typeof(PrimaryKeyAttribute)))
            .Select(p => $"@{p.Name}");
        return string.Join(", ", propertyNames);
    }

    private static DynamicParameters GetParameters(TEntity entity)
    {
        var parameters = new DynamicParameters();
        foreach (var property in typeof(TEntity).GetProperties())
        {
            parameters.Add($"@{property.Name}", property.GetValue(entity));
        }
        return parameters;
    }

    public string KeyValuePair(string key, string value)
    {
        string pairs = string.Empty;
        string[] keys = key.Split(',');
        string[] values = value.Split(',');

        for (int i = 0; i < keys.Length; i++)
        {
            string pair = keys[i].Trim() + "=" + values[i].Trim() +", ";
            pairs += pair;
        }
        return pairs.Substring(0 ,pairs.Length-2);
    }

    public string GetPrimaryKeyName()
    {
        var primaryKey = typeof(TEntity).GetProperties().Where(p => Attribute.IsDefined(p, typeof(PrimaryKeyAttribute))).First();
        return primaryKey.Name;
    }

    public string GetTableName(Type type)
    {
        var attribute = typeof(TEntity).GetCustomAttributes(typeof(TableAttribute), false).Cast<TableAttribute>().Single();
        return attribute.Name;
    }

}
