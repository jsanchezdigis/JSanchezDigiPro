using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            ML.Result result = new ML.Result
            {
                Objects = new List<object>()
            };
            try
            {
                using (var client = new HttpClient())
                {
                    string urlApi = ConfigurationManager.AppSettings["urlApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var responseTask = client.GetAsync("Materia/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }
                    }
                    materia.Materias = result.Objects;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
            }
            return View(materia);
        }

        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            if (IdMateria == null)
            {
                return View(materia);
            }
            else
            {
                ML.Result result = new ML.Result();

                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["urlApi"]);
                        var responseTask = client.GetAsync("Materia/GetById/" + IdMateria);
                        responseTask.Wait();

                        var resultService = responseTask.Result;

                        if (resultService.IsSuccessStatusCode)
                        {
                            var readTask = resultService.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();


                            ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            materia = (ML.Materia)result.Object;
                            return View(materia);
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se puedo hacer la consulta";
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Correct = false;
                        result.Exception = ex;
                        result.ErrorMessage = ex.Message;
                    }
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["urlApi"]);
                if (materia.IdMateria == 0)
                {
                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se completo el registro satisfactoriamente";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al insertar el registro";
                    }
                    return View("Modal");
                }
                else
                {
                    var postTask = client.PutAsJsonAsync<ML.Materia>("Materia/Update/" + materia.IdMateria, materia);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se actualizo el registro satisfactoriamente";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al actualizar el registro";
                    }
                    return View("Modal");
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(ML.Materia materia)
        {
            int IdMateria = materia.IdMateria;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["urlApi"]);
                var postTask = client.DeleteAsync("Materia/Delete/" + IdMateria);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se elimino el registro satisfactoriamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al eliminar el registro";
                }
                return View("Modal");
            }
        }
    }
}