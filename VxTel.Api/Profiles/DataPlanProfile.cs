using AutoMapper;
using VxTel.Api.Data.DTOs.DataPlan;
using VxTel.Api.Models;

namespace VxTel.Api.Profiles;

public class DataPlanProfile : Profile
{
    public DataPlanProfile()
    {
        CreateMap<DataPlan, ReadDataPlanDto>();
        CreateMap<CreateDataPlanDto, DataPlan>();
        CreateMap<UpdateDataPlanDto, DataPlan>();
    }
}