using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class DepartamentoController : Controller
    {
        public IActionResult GetAll()
        {
            BL.Empleado.Result result = BL.Departamento.GetAll();
            BL.Departamento.DepartamentoObj departamento = new BL.Departamento.DepartamentoObj();

            if (result.Correct)
            {
                departamento.Departamentos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(departamento);
        }
    }
}
