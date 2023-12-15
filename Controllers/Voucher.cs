using Microsoft.AspNetCore.Mvc;
using Api.models;
using Api.repositories;
using Api.utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Swashbuckle.AspNetCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Voucher(ILogger<Voucher> logger, IVoucherRepository repository) : ControllerBase
{   
    private readonly ILogger<Voucher> _logger = logger;
    private readonly IVoucherRepository _repository = repository;

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult GetAllVouchers(int id)
    {   
        IEnumerable<dynamic> vouchers = _repository.GetAll(id);
        return vouchers.Any() ? Ok(vouchers) : NotFound("Vouchers não encontrados para este usuário !");
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    public IActionResult CreateNewVoucher(NewVoucher voucher){
        string token = ApiUtils.CreateNewToken(); 
        int rowsAffected = _repository.New(voucher, token);

        return rowsAffected > 0 ? 
        StatusCode(201, new { voucher = token }) : NotFound(
                        "Usuário não encontrado");
                        
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteVoucher(int id)
    {
        int rowsAffected = _repository.Del(id);

        return rowsAffected > 0 
        ? NoContent() : NotFound("Voucher não encontrado !");
    }
}
