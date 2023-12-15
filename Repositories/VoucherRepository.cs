using Api.Database;
using Api.models;
using Dapper;

namespace Api.repositories;

public class VoucherRepository(IDatabaseConnection db): IVoucherRepository
{
    private readonly IDatabaseConnection _db = db;

    public IEnumerable<dynamic> GetAll(int id)
    {
        _db.Open();
        
        try
        {
            string query = $"select * from vouchers where user_id = {id}";
            IEnumerable<dynamic> vouchers = _db.Connection
                            .Query(
                                $"select * from vouchers where user_id = {id}"
                                );
            return vouchers;
        }
        finally
        {
            _db.Close();
        }
    }

    public int New(NewVoucher voucher, string result)
    {
        _db.Open();

        try
        {
        var data = new { Id = voucher.UserId, Token = result};
        var query = 
        $"INSERT INTO vouchers (user_id, voucher_token) VALUES (@Id, @Token)";
        var rowsAffected = _db.Connection.Execute(query, data);

            return rowsAffected;
        }
        catch(Exception e)
        {
            return 0;
        }
        finally
        {
            _db.Close();
        }
    }

    public int Del(int id){
        _db.Open();
        try
        {
            var data = new {Id = id};
            string query = $"DELETE FROM vouchers WHERE voucher_id = @Id";
            var rowsAffected = _db.Connection.Execute(query, data);
            return rowsAffected;
        }
        catch(Exception e){
            return 0;
        }
        finally
        {
            _db.Close();
        }
    }
}
