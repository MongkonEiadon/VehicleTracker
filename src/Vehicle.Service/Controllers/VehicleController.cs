using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Service.ViewModels;
using VehicleTracker.Application.QueryServices;
using VehicleTracker.Business.VehicleDomain;

namespace Vehicle.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleQueryService _vehicleQueryService;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleQueryService vehicleQueryService, IMapper mapper)
        {
            _vehicleQueryService = vehicleQueryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicle(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(nameof(NullReferenceException));


            var result = await _vehicleQueryService.GetVehicleByIdAsync(VehicleId.With(Guid.Parse(id)), cancellationToken);
            return new JsonResult(result);
        }


        [HttpPost]
        public async Task<IActionResult> StoreVehicle(VehicleViewModel vehicle, CancellationToken cancellationToken)
        {


            return Ok();
        }
    }
}
