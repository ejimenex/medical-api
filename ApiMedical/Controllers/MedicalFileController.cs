using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Dtos;
using AutoMapper;
using BussinesLogic.Interface;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using ApiMedical.Common.Pagination;
using ApiMedical.Auth;
using System.IO;
using System.Net.Http.Headers;
using Repository.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;

namespace ApiMedical.Controllers
{
    [Route("api/[controller]")]
    public class MedicalFileController : Controller
    {
        IHostingEnvironment hosting;
        readonly IGetData<Parameter> param;
        readonly IRepository<MedicalFile> fileMedical;
        public MedicalFileController(IGetData<Parameter> _param, IRepository<MedicalFile> _file, IHostingEnvironment _hosting) 
        {
            hosting = _hosting;
            param = _param;
            fileMedical = _file;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult SaveFile()
        {
            try
            {
                var _files = Request.Form.Files;
                var doctorGui = Request.Form["doctorGuid"].FirstOrDefault();
                var consultationId = Request.Form["consultationId"].FirstOrDefault();
                var patient = Request.Form["patient"].FirstOrDefault();
                var files = _files;
           
                string webRootPath = param.GetData().Where(c => c.Name == "DoctorFiles").FirstOrDefault().Value;
                string pathDr = Path.Combine(webRootPath, doctorGui.ToString());
                if (!Directory.Exists(pathDr))                
                    Directory.CreateDirectory(pathDr);

                string newPath = Path.Combine(pathDr,patient.ToString());
                if (!Directory.Exists(newPath))                
                    Directory.CreateDirectory(newPath);

               foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        string fullPath = Path.Combine(newPath, fileName);
                       if(!fileMedical.Exist(c=> c.FullPath == fullPath)) {
                            var newFile = new MedicalFile
                            {
                                FileName = fileName,
                                FullPath = fullPath,
                                FileExtension = "",
                                PatientGuid = new Guid(patient),
                                DoctorGuid = new Guid(doctorGui),
                                ConsultationId = Convert.ToInt32(consultationId)
                            };
                            fileMedical.Create(newFile);
                        }                       
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error en la subida de imagenes:" + ex.Message);
                throw;
            }
        }
        //[HttpGet]
        //[Route("GetDoctorPaginated")]
        //[AuthorizeMedical]
        //public IActionResult GetDoctorPaginated(ResourceParameters resource)
        //{
        //    if (resource.parameters == null) resource.parameters = "";
        //    var collection = _service.FindAll().Where(x => x.Name.Contains(resource.parameters) 
        //    || x.CountryWork.Name.Contains(resource.parameters));

        //    var dtos = _Mapper.ProjectTo<DoctorDto>(collection);
        //    var result = PagedList<DoctorDto>.Create(dtos, resource.PageNumber, resource.PageSize);
        //    var pagination = new
        //    {
        //        totalCount = result.TotalCount,
        //        pageSize = result.PageSize,
        //        currentPage = result.CurrentPage,
        //        totalPage = result.TotalPages,
        //        HasNext = result.HasNext,
        //        HasPrevious = result.HasPrevious,
        //        data = result
        //    };
        //    return Ok(pagination);
        //}
    }
}