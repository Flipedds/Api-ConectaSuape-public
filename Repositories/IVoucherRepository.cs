using Api.models;

namespace Api.repositories;

public interface IVoucherRepository
{
    IEnumerable<dynamic> GetAll(int id);
    int New(NewVoucher voucher, string result);

    int Del(int id);
}
