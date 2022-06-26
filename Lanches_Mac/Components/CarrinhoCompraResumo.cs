using Lanches_Mac1.Models;
using Lanches_Mac1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanches_Mac1.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {

        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        // Método Invoke, para retornar uma IViewComponentResult
        public IViewComponentResult Invoke()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            //Adicionando itens no carrinho manualmente.
            //var itens = new List<CarrinhoCompraItens>(){
            //    new CarrinhoCompraItens(),
            //    new CarrinhoCompraItens()
            //};

            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);

        }
    }
}
