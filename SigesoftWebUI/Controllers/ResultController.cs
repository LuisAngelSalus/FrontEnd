using BE;
using SigesoftWebUI.Controllers.Base;
using SigesoftWebUI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class ResultController : GenericController
    {
        ResultRepository resultRepository;

        public ResultController()
        {
            resultRepository = new ResultRepository();
        }

        // GET: Result
        public ActionResult Index()
        {
            List<ResultDto> response;

            response = resultRepository.GetResults(SessionUsuario).Data;

            return View(response);
        }


        public ActionResult Detail(int id)
        {
            List<ResultDetailDto> resultDetailDtos = null;

            var response = resultRepository.GetResultsDetail(id, SessionUsuario);
            if (response.IsSuccess)
            {
                resultDetailDtos = new List<ResultDetailDto>();
                resultDetailDtos = response.Data;
            }

            return PartialView("Detail", resultDetailDtos);

        }


    }
}