using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLWebApi.Controllers
{
    [RoutePrefix("api/departamento")]
    public class DepartamentoController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.AddEF(departamento);
            if (result.Correct)
            {
                //sE le pasa el mensaje que fue existoso
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                //Error que mando el usuario
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

       
        [Route("{IdDepartamento}")]
        [HttpDelete]
        //En postman se envia el id como numerico en la url y no se pone raw sino none para delete
        public IHttpActionResult Delete(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.DeleteEF(IdDepartamento);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdDepartamento}")]
        [HttpPut]
        public IHttpActionResult Update(int IdDepartamento, [FromBody] ML.Departamento departamento)
        {
            //Se iguala la variable para asi poder cacharla debido a que en este caso se piden dos parametros
            //La segunda es la variable declarada
            departamento.IdDepartamento = IdDepartamento;
            ML.Result result = BL.Departamento.UpdateEF(departamento);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdDepartamento}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll(ML.Departamento departamento)
        {
           
            ML.Result result = BL.Departamento.GetAllEF(departamento);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}

