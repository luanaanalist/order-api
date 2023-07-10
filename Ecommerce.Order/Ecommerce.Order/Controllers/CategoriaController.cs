using Domain.Entities;
using Ecommerce.Order.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Net.Mime;

namespace Ecommerce.Order.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var response = this._categoriaService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {

                return TratarExcecao(ControllerContext, "Ocorreu um erro ao tentar recuperar as categorias", ex);
            }


        }


        [HttpGet("GetById/{id}")]
        //[Route("GetById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var response = _categoriaService.GetById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {

                TratarExcecao(ControllerContext, "Ocorreu um erro ao tentar obter a Categoria.", ex);
                return null;
            }

        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCategoria(Categoria categoria)
        {
            try
            {
                var result = await this._categoriaService.Incluir(categoria);
                if (result)
                    return Ok("Categoria incluida com sucesso");
                else
                    return BadRequest("ocorreu um erro ao salvar a categoria");
            }
            catch (Exception ex)
            {

                return TratarExcecao(ControllerContext, "Ocorreu um erro ao tentar incluir uma Categoria.", ex);

            }

        }

        //[HttpPost]
        //public async Task<IActionResult> CadastrarCategoria(Categoria categoria)
        //{
        //    var result = await this._categoriaService.Incluir(categoria);
        //    if (result)
        //        return Ok("Categoria incluida com sucesso");


        //    return BadRequest("ocorreu um erro ao salvar a categoria");

        //}

        [HttpPut]
        public async Task<IActionResult> UpdateCategoria(Categoria categoria)
        {
            var result = await this._categoriaService.Update(categoria);
            if (result)
                return Ok("Categoria alterada com sucesso");


            return BadRequest("ocorreu um erro ao alterar a categoria");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await this._categoriaService.Excluir(id);
            if (result)
                return Ok("Categoria excluida com sucesso");


            return BadRequest("ocorreu um erro ao excluir a categoria");

            //}

        }
    }
}
