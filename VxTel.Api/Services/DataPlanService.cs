using AutoMapper;
using FluentResults;
using VxTel.Api.Data;
using VxTel.Api.Data.DTOs.DataPlan;
using VxTel.Api.Models;

namespace VxTel.Api.Services;

public class DataPlanService
{
    private VxTelDbContext _context;
    private IMapper _mapper;

    public DataPlanService(VxTelDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadDataPlanDto AddDataPlan(CreateDataPlanDto dataPlanDto)
    {
        DataPlan dataPlan = _mapper.Map<DataPlan>(dataPlanDto);
        _context.DataPlans.Add(dataPlan);
        _context.SaveChanges();
        return _mapper.Map<ReadDataPlanDto>(dataPlan);
    }

    public List<ReadDataPlanDto> GetDataPlans()
    {
        List<DataPlan> dataPlans = _context.DataPlans.ToList();
        return _mapper.Map<List<ReadDataPlanDto>>(dataPlans);
    }

    public ReadDataPlanDto GetDataPlanById(int id)
    {
        DataPlan dataPlan = _context.DataPlans.FirstOrDefault(plano => plano.Id == id);
        if (dataPlan != null)
        {
            return _mapper.Map<ReadDataPlanDto>(dataPlan);
        }
        return null;
    }

    public Result DeleteDataPlanById(int id)
    {
        DataPlan dataPlan = _context.DataPlans.FirstOrDefault(plano => plano.Id == id);
        if (dataPlan == null) return Result.Fail("Filme não encontrado");
        _context.Remove(dataPlan);
        _context.SaveChanges();
        return Result.Ok();
    }

}