using ApiMedical.Common.Filter;
using ApiMedical.Common.Pagination;
using Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Interface.ListInterface
{
    public interface IConsultationList
    {
        PagedData<ConsultationDto> GetPaged(ConsultationFilter filter);
    }
}
