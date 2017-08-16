using Cadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cadastro.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Usuario()
        {
            ClsUsuario objUsuario = new ClsUsuario();
            return View(objUsuario);
        }
        [HttpPost]
        public ActionResult Usuario(ClsUsuario objUsuario)
        {
            objUsuario.Grava(objUsuario);
            TempData["Usuario"] = "Dados Cadastrados com sucesso.";
            return View(objUsuario);
        }
        [HttpGet]
        public ActionResult ListaUsuario()
        {
            ClsUsuario objUsuario = new ClsUsuario();
            objUsuario.ListaUsuario = objUsuario.BusaLIstaUsuario();
            return View(objUsuario);
        }
        [HttpGet]
        public ActionResult Editar()
        {
            try
            {
                int idUsuario = Convert.ToInt32(Request.QueryString["idUsuario"]);
                ClsUsuario objUsuario = new ClsUsuario();
                objUsuario = objUsuario.BuscaUsuario(idUsuario);                
                return View(objUsuario);
            }
            catch (Exception er)
            {
                throw new Exception("ERRO AO TENTAR EDITAR O USUÁRIO...." + er.Message);
            }
        }
        [HttpPost]
        public ActionResult Editar(ClsUsuario objUsuario)
        {
            objUsuario.Editar(objUsuario);
            TempData["Usuario"] = "Dados editados com sucesso.";
            return View(objUsuario);
        }
    }
}